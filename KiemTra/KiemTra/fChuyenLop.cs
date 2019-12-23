using KiemTra.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemTra
{
    public partial class fChuyenLop : MetroFramework.Forms.MetroForm
    {
        private ModelContext db = new ModelContext();
        private SinhVien SinhVienIns = new SinhVien();
        private SinhVien svien;
        public fChuyenLop(SinhVien sv)
        {
            svien = sv;
            InitializeComponent();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void fChuyenLop_Load(object sender, EventArgs e)
        {
            cbLop.DataSource = db.Lops.ToList();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Bạn có chắc chắn muốn chuyển lớp?", "Cảnh báo!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Lop lop = db.Lops.Where(l => l.TenLop == cbLop.Text).FirstOrDefault() as Lop;
                int MaLop = lop.MaLop;
                try
                {
                    SinhVienIns.SuaSinhVien(svien.MasV, svien.HoTen, svien.GioiTinh, svien.NoiSinh, svien.QueQuan, MaLop);
                    MetroFramework.MetroMessageBox.Show(this, "Chuyển Lớp thành công!", "Thông báo!",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    insert();
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
