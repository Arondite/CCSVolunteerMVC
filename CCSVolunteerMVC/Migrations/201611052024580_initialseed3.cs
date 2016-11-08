namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialseed3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoursWorked", "positionLocation_positionLocationID", "dbo.PositionLocation");
            DropIndex("dbo.HoursWorked", new[] { "positionLocation_positionLocationID" });
            RenameColumn(table: "dbo.Volunteer", name: "ethnicity_ethnicityID", newName: "ethnicityID");
            RenameColumn(table: "dbo.HoursWorked", name: "positionLocation_positionLocationID", newName: "positionLocationID");
            RenameIndex(table: "dbo.Volunteer", name: "IX_ethnicity_ethnicityID", newName: "IX_ethnicityID");
            AlterColumn("dbo.HoursWorked", "positionLocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.HoursWorked", "positionLocationID");
            AddForeignKey("dbo.HoursWorked", "positionLocationID", "dbo.PositionLocation", "positionLocationID", cascadeDelete: true);
            DropColumn("dbo.Volunteer", "ethID");
            DropColumn("dbo.HoursWorked", "posLocationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoursWorked", "posLocationID", c => c.Int(nullable: false));
            AddColumn("dbo.Volunteer", "ethID", c => c.Int());
            DropForeignKey("dbo.HoursWorked", "positionLocationID", "dbo.PositionLocation");
            DropIndex("dbo.HoursWorked", new[] { "positionLocationID" });
            AlterColumn("dbo.HoursWorked", "positionLocationID", c => c.Int());
            RenameIndex(table: "dbo.Volunteer", name: "IX_ethnicityID", newName: "IX_ethnicity_ethnicityID");
            RenameColumn(table: "dbo.HoursWorked", name: "positionLocationID", newName: "positionLocation_positionLocationID");
            RenameColumn(table: "dbo.Volunteer", name: "ethnicityID", newName: "ethnicity_ethnicityID");
            CreateIndex("dbo.HoursWorked", "positionLocation_positionLocationID");
            AddForeignKey("dbo.HoursWorked", "positionLocation_positionLocationID", "dbo.PositionLocation", "positionLocationID");
        }
    }
}
