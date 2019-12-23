namespace KiemTra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NamHocs", "TenNamHoc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NamHocs", "TenNamHoc", c => c.Int(nullable: false));
        }
    }
}
