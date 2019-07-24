namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_article : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 200),
                        Title = c.String(maxLength: 200),
                        Slug = c.String(maxLength: 200),
                        Video = c.Int(nullable: false),
                        Remark = c.String(maxLength: 4000),
                        Position = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
