namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_content : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "PublicDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "PublicDate");
        }
    }
}
