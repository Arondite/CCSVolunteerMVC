namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldForDatabaseHelper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoursWorkeds", "IsClockedIn", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HoursWorkeds", "IsClockedIn");
        }
    }
}
