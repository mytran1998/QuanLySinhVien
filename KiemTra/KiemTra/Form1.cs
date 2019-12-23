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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private ModelContext db = new ModelContext();
        private Lop LopInstance = new Lop();
        private SinhVien SinhVienIns = new SinhVien();
        public Form1()
        {
            InitializeComponent();
        }

        private void fLop_UpdateEventHandler(object sender, fLop.UpdateEventArgs args)
        {
            using (ModelContext db = new ModelContext())
            {
                lopBindingSource.DataSource = db.Lops.ToList();
                sinhVienBindingSource.DataSource = db.SinhViens.ToList();
            }
        }

        private void fSinhVien_UpdateEventHandler(object sender, fSinhVien.UpdateEventArgs args)
        {
            using (ModelContext db = new ModelContext())
            {
                lopBindingSource.DataSource = db.Lops.ToList();
                sinhVienBindingSource.DataSource = db.SinhViens.ToList();
            }
        }

        private void fChuyenLop_UpdateEventHandler(object sender, fChuyenLop.UpdateEventArgs args)
        {
            using (ModelContext db = new ModelContext())
            {
                lopBindingSource.DataSource = db.Lops.ToList();
                sinhVienBindingSource.DataSource = db.SinhViens.ToList();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lopBindingSource.DataSource = db.Lops.ToList();
            sinhVienBindingSource.DataSource = db.SinhViens.ToList();
            cbKhoiHoc.DataSource = db.Khois.ToList();
            cbNamHoc.DataSource = db.NamHocs.ToList();
            List<Lop> lstLop = db.Lops.ToList();
            List<SinhVien> lstSinhVien = db.SinhViens.ToList();
            if(lstLop.Count() != 0)
                lbSoLop.Text = lstLop.Count().ToString();
            if(lstSinhVien.Count() != 0)
                lbHocSinh.Text = lstSinhVien.Count().ToString();
        }

        private void dtgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Lop lop = lopBindingSource.Current as Lop;
            if(lop != null)
            {
                sinhVienBindingSource.DataSource = db.SinhViens.Where(s => s.MaLop == lop.MaLop).ToList();
            }
        }

        private void cbKhoiHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Khoi kh = db.Khois.Where(k => k.TenKhoi == cbKhoiHoc.Text).FirstOrDefault() as Khoi;
            if(kh != null)
            {
                lopBindingSource.DataSource = db.Lops.Where(s => s.MaKhoi == kh.MaKhoi).ToList();
            }
        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Khoi kh = db.Khois.Where(k => k.TenKhoi == cbKhoiHoc.Text).FirstOrDefault() as Khoi;
            if(kh != null)
            {
                NamHoc nh = db.NamHocs.Where(k => k.TenNamHoc == cbNamHoc.Text).FirstOrDefault() as NamHoc;
                if(nh != null)
                {
                    lopBindingSource.DataSource = db.Lops.Where(s => s.MaKhoi == kh.MaKhoi && kh.MaNamHoc == nh.MaNamHoc).ToList();
                }
            }
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            var fThem = new fLop(null);
            fThem.UpdateEventHandler += fLop_UpdateEventHandler;
            fThem.ShowDialog();
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            Lop lop = lopBindingSource.Current as Lop;
            if(lop != null)
            {
                var fSua = new fLop(lop);
                fSua.UpdateEventHandler += fLop_UpdateEventHandler;
                fSua.ShowDialog();
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Bạn có chắc chắn muốn xóa?", "Cảnh báo!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Lop lp = lopBindingSource.Current as Lop;
                if (lp != null)
                {
                    if(lp.SiSo == 0)
                    {
                        try
                        {
                            LopInstance.XoaLop(lp.MaLop);
                            lopBindingSource.RemoveCurrent();
                        }
                        catch (Exception ex)
                        {
                            MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Không thể xóa lớp có sinh viên!", "Thông báo!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void btnThemSinhVien_Click(object sender, EventArgs e)
        {
            var fSinhVien = new fSinhVien(null);
            fSinhVien.UpdateEventHandler += fSinhVien_UpdateEventHandler;
            fSinhVien.ShowDialog();
        }

        private void btnSuaSinhVien_Click(object sender, EventArgs e)
        {
            SinhVien sv = sinhVienBindingSource.Current as SinhVien;
            if(sv != null)
            {
                var fSinhVien = new fSinhVien(sv);
                fSinhVien.UpdateEventHandler += fSinhVien_UpdateEventHandler;
                fSinhVien.ShowDialog();
            }
        }

        private void btnXoaSinhVien_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Bạn có chắc chắn muốn xóa?", "Cảnh báo!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SinhVien sv = sinhVienBindingSource.Current as SinhVien;
                if (sv != null)
                {
                    try
                    {
                        SinhVienIns.XoaSinhVien(sv.MasV);
                        sinhVienBindingSource.RemoveCurrent();
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SinhVien sv = sinhVienBindingSource.Current as SinhVien;
            if(sv != null)
            {
                var fChuyenLop = new fChuyenLop(sv);
                fChuyenLop.UpdateEventHandler += fChuyenLop_UpdateEventHandler;
                fChuyenLop.ShowDialog();
            }
        }
    }
}
