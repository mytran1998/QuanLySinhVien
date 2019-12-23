using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.Entity
{
    public class NamHoc
    {
        [Key]
        public int MaNamHoc { get; set; }

        public string TenNamHoc { get; set; }

        public virtual ICollection<Khoi> Khois { get; set; }
    }
}
