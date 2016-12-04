namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Position",
            //    c => new
            //        {
            //            PositionID = c.Int(nullable: false, identity: true),
            //            PositionTitle = c.String(),
            //            PositionLocation_positionLocationID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.PositionID)
            //    .ForeignKey("dbo.PositionLocation", t => t.PositionLocation_positionLocationID)
            //    .Index(t => t.PositionLocation_positionLocationID);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Position", "PositionLocation_positionLocationID", "dbo.PositionLocation");
            //DropIndex("dbo.Position", new[] { "PositionLocation_positionLocationID" });
            //DropTable("dbo.Position");
        }
    }
}
