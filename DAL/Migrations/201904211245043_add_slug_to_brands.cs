namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_slug_to_brands : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "Slug");
        }
    }
}
