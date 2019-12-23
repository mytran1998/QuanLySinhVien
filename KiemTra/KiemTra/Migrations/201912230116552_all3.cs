namespace KiemTra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lops", "Khoi_MaKhoi", "dbo.Khois");
            DropIndex("dbo.Lops", new[] { "Khoi_MaKhoi" });
            RenameColumn(table: "dbo.Lops", name: "Khoi_MaKhoi", newName: "MaKhoi");
            AlterColumn("dbo.Lops", "MaKhoi", c => c.Int(nullable: false));
            CreateIndex("dbo.Lops", "MaKhoi");
            AddForeignKey("dbo.Lops", "MaKhoi", "dbo.Khois", "MaKhoi", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lops", "MaKhoi", "dbo.Khois");
            DropIndex("dbo.Lops", new[] { "MaKhoi" });
            AlterColumn("dbo.Lops", "MaKhoi", c => c.Int());
            RenameColumn(table: "dbo.Lops", name: "MaKhoi", newName: "Khoi_MaKhoi");
            CreateIndex("dbo.Lops", "Khoi_MaKhoi");
            AddForeignKey("dbo.Lops", "Khoi_MaKhoi", "dbo.Khois", "MaKhoi");
        }
    }
}
