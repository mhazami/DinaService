namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contents", "BrandsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "BrandsId", c => c.Int(nullable: false));
        }
    }
}
