namespace KiemTra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khois",
                c => new
                    {
                        MaKhoi = c.Int(nullable: false, identity: true),
                        TenKhoi = c.String(maxLength: 50),
                        MaNamHoc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhoi)
                .ForeignKey("dbo.NamHocs", t => t.MaNamHoc, cascadeDelete: true)
                .Index(t => t.MaNamHoc);
            
            CreateTable(
                "dbo.Lops",
                c => new
                    {
                        MaLop = c.Int(nullable: false, identity: true),
                        TenLop = c.String(maxLength: 50),
                        PhongHoc = c.String(maxLength: 50),
                        SiSo = c.Int(nullable: false),
                        Khoi_MaKhoi = c.Int(),
                    })
                .PrimaryKey(t => t.MaLop)
                .ForeignKey("dbo.Khois", t => t.Khoi_MaKhoi)
                .Index(t => t.Khoi_MaKhoi);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MasV = c.Int(nullable: false, identity: true),
                        HoTen = c.String(maxLength: 50),
                        GioiTinh = c.Boolean(nullable: false),
                        NoiSinh = c.String(maxLength: 50),
                        QueQuan = c.String(maxLength: 50),
                        MaLop = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MasV)
                .ForeignKey("dbo.Lops", t => t.MaLop, cascadeDelete: true)
                .Index(t => t.MaLop);
            
            CreateTable(
                "dbo.NamHocs",
                c => new
                    {
                        MaNamHoc = c.Int(nullable: false, identity: true),
                        TenNamHoc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNamHoc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Khois", "MaNamHoc", "dbo.NamHocs");
            DropForeignKey("dbo.SinhViens", "MaLop", "dbo.Lops");
            DropForeignKey("dbo.Lops", "Khoi_MaKhoi", "dbo.Khois");
            DropIndex("dbo.SinhViens", new[] { "MaLop" });
            DropIndex("dbo.Lops", new[] { "Khoi_MaKhoi" });
            DropIndex("dbo.Khois", new[] { "MaNamHoc" });
            DropTable("dbo.NamHocs");
            DropTable("dbo.SinhViens");
            DropTable("dbo.Lops");
            DropTable("dbo.Khois");
        }
    }
}
