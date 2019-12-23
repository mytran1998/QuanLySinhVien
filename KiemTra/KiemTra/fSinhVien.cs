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
    public partial class fSinhVien : MetroFramework.Forms.MetroForm
    {
        private SinhVien SVien;
        private SinhVien SinhVienIns = new SinhVien();
        private ModelContext db = new ModelContext();
        public fSinhVien(SinhVien sv)
        {
            SVien = sv;
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
            string HoTen = txtHoTen.Text;
            string NoiSinh = txtNoiSinh.Text;
            string QueQuan = txtQueQuan.Text;
            bool GioiTinh = cbGioiTinh.Checked;
            Lop lop = db.Lops.Where(l => l.TenLop == cbLop.Text).FirstOrDefault() as Lop;
            int MaLop = lop.MaLop;

            if (HoTen.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập họ tên!", "Thông báo!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (NoiSinh.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập nơi sinh!", "Thông báo!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (QueQuan.Equals(""))
            {
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập quê quán!", "Thông báo!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (SVien == null)
                {
                    // Them
                    SinhVien sv = new SinhVien()
                    {
                        HoTen = HoTen,
                        GioiTinh = GioiTinh,
                        NoiSinh = NoiSinh, 
                        QueQuan = QueQuan, 
                        MaLop = MaLop
                    };
                    SinhVienIns.ThemSinhVien(sv);
                    MetroFramework.MetroMessageBox.Show(this, "Thêm thành công!", "Thông báo!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Sua
                    SinhVienIns.SuaSinhVien(SVien.MasV, HoTen, GioiTinh, NoiSinh, QueQuan, MaLop);
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

        private void fSinhVien_Load(object sender, EventArgs e)
        {
            cbLop.DataSource = db.Lops.ToList();
            if(SVien != null)
            {
                txtHoTen.Text = SVien.HoTen;
                txtNoiSinh.Text = SVien.NoiSinh;
                txtQueQuan.Text = SVien.QueQuan;
                cbGioiTinh.Checked = SVien.GioiTinh;
            }
        }
    }
}
