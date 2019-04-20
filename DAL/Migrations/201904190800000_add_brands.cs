namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_brands : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "FileId", "dbo.Files");
            DropIndex("dbo.Contents", new[] { "FileId" });
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Link = c.String(),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BrandsId);
            
            AddColumn("dbo.Contents", "BrandsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "BrandsId");
            DropTable("dbo.Brands");
            CreateIndex("dbo.Contents", "FileId");
            AddForeignKey("dbo.Contents", "FileId", "dbo.Files", "Id", cascadeDelete: true);
        }
    }
}
