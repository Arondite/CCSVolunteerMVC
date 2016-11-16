namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingAdditionalParameters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteer", "ethName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "ethName");
        }
    }
}
