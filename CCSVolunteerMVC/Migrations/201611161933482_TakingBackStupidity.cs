namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TakingBackStupidity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Volunteer", "ethName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Volunteer", "ethName", c => c.String());
        }
    }
}
