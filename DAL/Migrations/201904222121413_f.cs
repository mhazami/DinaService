namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "BId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "BId");
        }
    }
}
