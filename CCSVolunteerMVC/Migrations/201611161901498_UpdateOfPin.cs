namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOfPin : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Volunteer", "volPin", c => c.String());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Volunteer", "volPin", c => c.Int(nullable: false));
        }
    }
}
