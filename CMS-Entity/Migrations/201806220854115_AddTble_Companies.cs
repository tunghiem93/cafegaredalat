namespace CMS_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTble_Companies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CMS_Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 250),
                        LinkBlog = c.String(maxLength: 250, unicode: false),
                        LinkFB = c.String(maxLength: 250, unicode: false),
                        LinkTwiter = c.String(maxLength: 250, unicode: false),
                        LinkInstagram = c.String(maxLength: 250, unicode: false),
                        ImageURL = c.String(maxLength: 60, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CMS_Categories", "ImageURL", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.CMS_Employee", "Level", c => c.String());
            AddColumn("dbo.CMS_Employee", "LinkBlog", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.CMS_Employee", "LinkFB", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.CMS_Employee", "LinkTwiter", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.CMS_Employee", "LinkInstagram", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.CMS_Employee", "IsSupperAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CMS_Employee", "IsSupperAdmin");
            DropColumn("dbo.CMS_Employee", "LinkInstagram");
            DropColumn("dbo.CMS_Employee", "LinkTwiter");
            DropColumn("dbo.CMS_Employee", "LinkFB");
            DropColumn("dbo.CMS_Employee", "LinkBlog");
            DropColumn("dbo.CMS_Employee", "Level");
            DropColumn("dbo.CMS_Categories", "ImageURL");
            DropTable("dbo.CMS_Companies");
        }
    }
}
