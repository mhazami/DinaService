namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_content : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.FileId, cascadeDelete: true)
                .Index(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "FileId", "dbo.Files");
            DropIndex("dbo.Contents", new[] { "FileId" });
            DropTable("dbo.Contents");
        }
    }
}
