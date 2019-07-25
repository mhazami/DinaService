namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Address = c.String(nullable: false),
                        ApplicationType = c.Int(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "VideoDesc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "VideoDesc");
            DropTable("dbo.Requests");
        }
    }
}
