using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra.Entity
{
    public class ModelContext:DbContext
    {
        public ModelContext() : base("name=con") { }

        public DbSet<SinhVien> SinhViens { get; set; }

        public DbSet<Lop> Lops { get; set; }

        public DbSet<Khoi> Khois { get; set; }

        public DbSet<NamHoc> NamHocs { get; set; }
    }
}
