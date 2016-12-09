namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedNullableEthnicity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Volunteers", "ethnicityID", "dbo.Ethnicities");
            DropIndex("dbo.Volunteers", new[] { "ethnicityID" });
            AlterColumn("dbo.Volunteers", "ethnicityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Volunteers", "ethnicityID");
            AddForeignKey("dbo.Volunteers", "ethnicityID", "dbo.Ethnicities", "ethnicityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "ethnicityID", "dbo.Ethnicities");
            DropIndex("dbo.Volunteers", new[] { "ethnicityID" });
            AlterColumn("dbo.Volunteers", "ethnicityID", c => c.Int());
            CreateIndex("dbo.Volunteers", "ethnicityID");
            AddForeignKey("dbo.Volunteers", "ethnicityID", "dbo.Ethnicities", "ethnicityID");
        }
    }
}
