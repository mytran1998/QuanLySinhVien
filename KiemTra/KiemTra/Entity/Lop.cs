using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.Entity
{
    public class Lop
    {
        [Key]
        public int MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        [StringLength(50)]
        public string PhongHoc { get; set; }

        public int SiSo { get; set; }

        public int MaKhoi { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }

        public virtual Khoi Khoi { get; set; }

        public void ThemLop(Lop lop)
        {
            using (ModelContext db = new ModelContext())
            {
                db.Lops.Add(lop);
                db.SaveChanges();
            }
        }

        public void SuaLop(int MaLop, string TenLop, string PhongHoc, int SiSo, int MaKhoi)
        {
            using(ModelContext db = new ModelContext())
            {
                Lop lop = db.Lops.Where(e => e.MaLop == MaLop).FirstOrDefault() as Lop;
                if (lop != null)
                {
                    lop.TenLop = TenLop;
                    lop.PhongHoc = PhongHoc;
                    lop.SiSo = SiSo;
                    lop.MaKhoi = MaKhoi;
                }
                db.SaveChanges();
            }
        }

        public void XoaLop(int MaLop)
        {
            using (ModelContext db = new ModelContext())
            {
                Lop lop = db.Lops.Where(l => l.MaLop == MaLop).FirstOrDefault() as Lop;
                if(lop != null)
                {
                    db.Lops.Remove(lop);
                }
                db.SaveChanges();
            }
        }
    
    }
}
