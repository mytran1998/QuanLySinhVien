using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.Entity
{
    public class Khoi
    {
        [Key]
        public int MaKhoi { get; set; }

        [StringLength(50)]
        public string TenKhoi { get; set; }

        public int MaNamHoc { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }

        public virtual NamHoc NamHoc { get; set; }
    }
}
