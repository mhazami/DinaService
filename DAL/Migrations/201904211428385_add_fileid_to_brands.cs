namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_fileid_to_brands : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "FileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "FileId");
        }
    }
}
