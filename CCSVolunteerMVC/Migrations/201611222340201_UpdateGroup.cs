namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupContact", "volunteerGroupID", "dbo.VolunteerGroup");
            DropForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup");
            DropPrimaryKey("dbo.VolunteerGroup");
            AlterColumn("dbo.VolunteerGroup", "volunteerGroupID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.VolunteerGroup", "volunteerGroupID");
            AddForeignKey("dbo.GroupContact", "volunteerGroupID", "dbo.VolunteerGroup", "volunteerGroupID");
            AddForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup", "volunteerGroupID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup");
            DropForeignKey("dbo.GroupContact", "volunteerGroupID", "dbo.VolunteerGroup");
            DropPrimaryKey("dbo.VolunteerGroup");
            AlterColumn("dbo.VolunteerGroup", "volunteerGroupID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VolunteerGroup", "volunteerGroupID");
            AddForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup", "volunteerGroupID", cascadeDelete: true);
            AddForeignKey("dbo.GroupContact", "volunteerGroupID", "dbo.VolunteerGroup", "volunteerGroupID");
        }
    }
}
