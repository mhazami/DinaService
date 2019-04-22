namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "BrandsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "BrandsId", c => c.Int(nullable: false));
        }
    }
}
