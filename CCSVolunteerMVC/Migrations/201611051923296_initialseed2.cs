namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialseed2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ethnicity", "ethName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ethnicity", "ethName", c => c.String(maxLength: 20));
        }
    }
}
