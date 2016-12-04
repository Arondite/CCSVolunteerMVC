namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CompletedTraining", newName: "CompletedTrainings");
            RenameTable(name: "dbo.Volunteer", newName: "Volunteers");
            RenameTable(name: "dbo.CourtOrdered", newName: "CourtOrdereds");
            RenameTable(name: "dbo.Ethnicity", newName: "Ethnicities");
            RenameTable(name: "dbo.HoursWorked", newName: "HoursWorkeds");
            RenameTable(name: "dbo.PositionLocation", newName: "PositionLocations");
            RenameTable(name: "dbo.Position", newName: "Positions");
            RenameTable(name: "dbo.VolunteerLanguage", newName: "VolunteerLanguages");
            RenameTable(name: "dbo.ForeignLanguage", newName: "ForeignLanguages");
            RenameTable(name: "dbo.VolunteerTraining", newName: "VolunteerTrainings");
            RenameTable(name: "dbo.Contact", newName: "Contacts");
            RenameTable(name: "dbo.ContactType", newName: "ContactTypes");
            RenameTable(name: "dbo.GroupContact", newName: "GroupContacts");
            RenameTable(name: "dbo.VolunteerGroup", newName: "VolunteerGroups");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.VolunteerGroups", newName: "VolunteerGroup");
            RenameTable(name: "dbo.GroupContacts", newName: "GroupContact");
            RenameTable(name: "dbo.ContactTypes", newName: "ContactType");
            RenameTable(name: "dbo.Contacts", newName: "Contact");
            RenameTable(name: "dbo.VolunteerTrainings", newName: "VolunteerTraining");
            RenameTable(name: "dbo.ForeignLanguages", newName: "ForeignLanguage");
            RenameTable(name: "dbo.VolunteerLanguages", newName: "VolunteerLanguage");
            RenameTable(name: "dbo.Positions", newName: "Position");
            RenameTable(name: "dbo.PositionLocations", newName: "PositionLocation");
            RenameTable(name: "dbo.HoursWorkeds", newName: "HoursWorked");
            RenameTable(name: "dbo.Ethnicities", newName: "Ethnicity");
            RenameTable(name: "dbo.CourtOrdereds", newName: "CourtOrdered");
            RenameTable(name: "dbo.Volunteers", newName: "Volunteer");
            RenameTable(name: "dbo.CompletedTrainings", newName: "CompletedTraining");
        }
    }
}
