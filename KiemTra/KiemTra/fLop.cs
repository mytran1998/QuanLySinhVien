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
    public partial class fLop : MetroFramework.Forms.MetroForm
    {
        private Lop lp;
        private ModelContext db = new ModelContext();
        private Lop LopIns = new Lop();
        public fLop(Lop lop)
        {
            lp = lop;
            InitializeComponent();
        }

        // LOAD LẠI FORM1 
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string TenLop = txtTenLop.Text;
            string SiSo = txtSiSo.Text;
            string PhongHoc = txtPhong.Text;
            Khoi kh = db.Khois.Where(k => k.TenKhoi == cbKhoi.Text).FirstOrDefault() as Khoi;
            int MaKhoi = kh.MaKhoi;
            if (TenLop.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập tên lớp!", "Thông báo!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (SiSo.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập sĩ số!", "Thông báo!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PhongHoc.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập phòng học!", "Thông báo!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                
                if(lp == null)
                {
                    Lop temp = new Lop()
                    {
                        TenLop = TenLop,
                        PhongHoc = PhongHoc,
                        SiSo = Int32.Parse(SiSo),
                        MaKhoi = MaKhoi
                    };
                    LopIns.ThemLop(temp);
                    // Them
                    MetroFramework.MetroMessageBox.Show(this, "Thêm thành công!", "Thông báo!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Sua
                    LopIns.SuaLop(lp.MaLop, TenLop, PhongHoc, Int32.Parse(SiSo), MaKhoi);
                    MetroFramework.MetroMessageBox.Show(this, "Sửa thành công!", "Thông báo!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.Close();
                insert();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fLop_Load(object sender, EventArgs e)
        {
            cbKhoi.DataSource = db.Khois.ToList();
            if(lp != null)
            {
                txtTenLop.Text = lp.TenLop;
                txtPhong.Text = lp.PhongHoc;
                txtSiSo.Text = lp.SiSo.ToString();
            }
        }
    }
}
