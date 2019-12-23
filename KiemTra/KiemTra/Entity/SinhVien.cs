using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.Entity
{
    public class SinhVien
    {
        [Key]
        public int MasV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public bool GioiTinh { get; set; }

        [StringLength(50)]
        public string NoiSinh { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        public int MaLop { get; set; }

        public virtual Lop lop { get; set; }

        public void ThemSinhVien(SinhVien sv)
        {
            using (ModelContext db = new ModelContext())
            {
                db.SinhViens.Add(sv);
                db.SaveChanges();
            }
        }

        public void SuaSinhVien(int MaSV, string Ten, bool GioiTinh, string NoiSinh, string QueQuan, int MaLop)
        {
            using (ModelContext db = new ModelContext())
            {
                SinhVien sv = db.SinhViens.Where(e => e.MasV == MaSV).FirstOrDefault();
                if (sv != null)
                {
                    sv.HoTen = Ten;
                    sv.GioiTinh = GioiTinh;
                    sv.NoiSinh = NoiSinh;
                    sv.QueQuan = QueQuan;
                    sv.MaLop = MaLop;
                }
                db.SaveChanges();
            }
        }

        public void XoaSinhVien(int MaSV)
        {
            using (ModelContext db = new ModelContext())
            {
                SinhVien sv = db.SinhViens.Where(e => e.MasV == MaSV).FirstOrDefault() as SinhVien;
                if (sv != null)
                {
                    db.SinhViens.Remove(sv);
                }
                db.SaveChanges();
            }
        }

    }
}
