namespace CMS_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modTblCompany_addColBusssinessHour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CMS_Companies", "BusinessHour", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CMS_Companies", "BusinessHour");
        }
    }
}
