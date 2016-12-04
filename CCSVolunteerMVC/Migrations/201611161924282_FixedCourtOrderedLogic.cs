namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCourtOrderedLogic : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Volunteer", "volsCourtOrdered", c => c.String());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Volunteer", "volsCourtOrdered", c => c.Int(nullable: false));
        }
    }
}
