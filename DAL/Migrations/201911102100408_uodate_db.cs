namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uodate_db : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "Message", c => c.String(nullable: false));
        }
    }
}
