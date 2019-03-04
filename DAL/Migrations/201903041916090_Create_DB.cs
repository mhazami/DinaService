namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Guid(nullable: false),
                        Context = c.Binary(),
                        ContextType = c.String(nullable: false, maxLength: 10),
                        Title = c.String(nullable: false, maxLength: 50),
                        FileSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Files");
        }
    }
}
