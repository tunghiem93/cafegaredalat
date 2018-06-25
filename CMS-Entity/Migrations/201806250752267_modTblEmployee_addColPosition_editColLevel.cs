namespace CMS_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modTblEmployee_addColPosition_editColLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CMS_Employee", "Position", c => c.String(maxLength: 100));
            AlterColumn("dbo.CMS_Employee", "Level", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CMS_Employee", "Level", c => c.String());
            DropColumn("dbo.CMS_Employee", "Position");
        }
    }
}
