namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableIDsInHoursWorked : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoursWorked", "volunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup");
            DropIndex("dbo.HoursWorked", new[] { "volunteerID" });
            DropIndex("dbo.HoursWorked", new[] { "volunteerGroupID" });
            AlterColumn("dbo.HoursWorked", "volunteerID", c => c.Int());
            AlterColumn("dbo.HoursWorked", "volunteerGroupID", c => c.Int());
            CreateIndex("dbo.HoursWorked", "volunteerID");
            CreateIndex("dbo.HoursWorked", "volunteerGroupID");
            AddForeignKey("dbo.HoursWorked", "volunteerID", "dbo.Volunteer", "volunteerID");
            AddForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup", "volunteerGroupID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup");
            DropForeignKey("dbo.HoursWorked", "volunteerID", "dbo.Volunteer");
            DropIndex("dbo.HoursWorked", new[] { "volunteerGroupID" });
            DropIndex("dbo.HoursWorked", new[] { "volunteerID" });
            AlterColumn("dbo.HoursWorked", "volunteerGroupID", c => c.Int(nullable: false));
            AlterColumn("dbo.HoursWorked", "volunteerID", c => c.Int(nullable: false));
            CreateIndex("dbo.HoursWorked", "volunteerGroupID");
            CreateIndex("dbo.HoursWorked", "volunteerID");
            AddForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup", "volunteerGroupID", cascadeDelete: true);
            AddForeignKey("dbo.HoursWorked", "volunteerID", "dbo.Volunteer", "volunteerID", cascadeDelete: true);
        }
    }
}
