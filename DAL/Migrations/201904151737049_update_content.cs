namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_content : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Files");
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Alt = c.String(nullable: false),
                        KeyWords = c.String(),
                        Slug = c.String(),
                        Place = c.Byte(nullable: false),
                        PublicDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Files", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Files", "Id");
            DropColumn("dbo.Files", "FileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "FileId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.Files");
            DropColumn("dbo.Files", "Id");
            DropTable("dbo.Contents");
            AddPrimaryKey("dbo.Files", "FileId");
        }
    }
}
