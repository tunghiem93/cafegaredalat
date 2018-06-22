namespace CMS_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CMS_Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        CategoryName = c.String(nullable: false, maxLength: 250),
                        CategoryCode = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(),
                        ImageURL = c.String(maxLength: 60, unicode: false),
                        ParentId = c.String(maxLength: 60, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CMS_Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        ProductCode = c.String(nullable: false, maxLength: 50, unicode: false),
                        ProductName = c.String(nullable: false, maxLength: 250),
                        ProductPrice = c.Decimal(precision: 18, scale: 2),
                        CategoryId = c.String(nullable: false, maxLength: 60, unicode: false),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CMS_Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CMS_Images",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        ImageURL = c.String(maxLength: 60, unicode: false),
                        ProductId = c.String(maxLength: 60, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CMS_Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.CMS_Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        CompanyName = c.String(maxLength: 250),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        Password = c.String(nullable: false, maxLength: 250, unicode: false),
                        Phone = c.String(maxLength: 15, unicode: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Address = c.String(nullable: false, maxLength: 250),
                        MaritalStatus = c.Boolean(nullable: false),
                        Street = c.String(maxLength: 250),
                        City = c.String(),
                        Country = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CMS_Employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Level = c.String(),
                        Employee_Address = c.String(maxLength: 250),
                        Employee_Phone = c.String(nullable: false, maxLength: 11, unicode: false),
                        Employee_Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Employee_IDCard = c.String(maxLength: 50, unicode: false),
                        BirthDate = c.DateTime(),
                        Password = c.String(nullable: false, maxLength: 250, unicode: false),
                        LinkBlog = c.String(maxLength: 250, unicode: false),
                        LinkFB = c.String(maxLength: 250, unicode: false),
                        LinkTwiter = c.String(maxLength: 250, unicode: false),
                        LinkInstagram = c.String(maxLength: 250, unicode: false),
                        ImageURL = c.String(maxLength: 60, unicode: false),
                        IsSupperAdmin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CMS_News",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Short_Description = c.String(nullable: false, maxLength: 500),
                        Description = c.String(storeType: "ntext"),
                        ImageURL = c.String(maxLength: 60, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CMS_Policy",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 60, unicode: false),
                        Description = c.String(storeType: "ntext"),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 60, unicode: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 60, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CMS_Images", "ProductId", "dbo.CMS_Products");
            DropForeignKey("dbo.CMS_Products", "CategoryId", "dbo.CMS_Categories");
            DropIndex("dbo.CMS_Images", new[] { "ProductId" });
            DropIndex("dbo.CMS_Products", new[] { "CategoryId" });
            DropTable("dbo.CMS_Policy");
            DropTable("dbo.CMS_News");
            DropTable("dbo.CMS_Employee");
            DropTable("dbo.CMS_Customers");
            DropTable("dbo.CMS_Images");
            DropTable("dbo.CMS_Products");
            DropTable("dbo.CMS_Categories");
        }
    }
}
