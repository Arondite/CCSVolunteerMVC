namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompletedTrainings",
                c => new
                    {
                        completedTrainingID = c.Int(nullable: false, identity: true),
                        volunteerID = c.Int(nullable: false),
                        volunteerTrainingID = c.Int(nullable: false),
                        cmpTrnDate = c.DateTime(nullable: false),
                        cmpTrnComments = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.completedTrainingID)
                .ForeignKey("dbo.Volunteers", t => t.volunteerID, cascadeDelete: true)
                .ForeignKey("dbo.VolunteerTrainings", t => t.volunteerTrainingID, cascadeDelete: true)
                .Index(t => t.volunteerID)
                .Index(t => t.volunteerTrainingID);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        volunteerID = c.Int(nullable: false, identity: true),
                        volFirstName = c.String(),
                        volLastName = c.String(),
                        volDOB = c.DateTime(nullable: false),
                        volPin = c.String(),
                        volGender = c.String(),
                        volJoinDate = c.DateTime(nullable: false),
                        volsCourtOrdered = c.Int(nullable: false),
                        ethnicityID = c.Int(),
                        volsClient = c.Byte(nullable: false),
                        volsActive = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.volunteerID)
                .ForeignKey("dbo.Ethnicities", t => t.ethnicityID)
                .Index(t => t.ethnicityID);
            
            CreateTable(
                "dbo.CourtOrdereds",
                c => new
                    {
                        courtOrderedID = c.Int(nullable: false, identity: true),
                        volunteerID = c.Int(),
                        crtOrderCaseNumber = c.String(maxLength: 15),
                        crtOrderedHoursRequired = c.Int(nullable: false),
                        crtOrderedStartDate = c.DateTime(nullable: false),
                        crtOrderedSexOrViolentCrime = c.Int(nullable: false),
                        crtOrderedOneMonthLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.courtOrderedID)
                .ForeignKey("dbo.Volunteers", t => t.volunteerID)
                .Index(t => t.volunteerID);
            
            CreateTable(
                "dbo.Ethnicities",
                c => new
                    {
                        ethnicityID = c.Int(nullable: false, identity: true),
                        ethName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ethnicityID);
            
            CreateTable(
                "dbo.HoursWorkeds",
                c => new
                    {
                        hoursWorkedID = c.Int(nullable: false, identity: true),
                        positionLocationID = c.Int(nullable: false),
                        hrsWrkdIDType = c.String(maxLength: 1),
                        hrsWrkdTimeIn = c.DateTime(nullable: false),
                        hrsWrkdTimeOut = c.DateTime(nullable: false),
                        userAcctID = c.Int(nullable: false),
                        modifiedOn = c.DateTime(nullable: false),
                        hrsWrkedSchedDate = c.DateTime(nullable: false),
                        volunteerID = c.Int(),
                        volunteerGroupID = c.Int(),
                        hrsWrkdQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.hoursWorkedID)
                .ForeignKey("dbo.PositionLocations", t => t.positionLocationID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteers", t => t.volunteerID)
                .ForeignKey("dbo.VolunteerGroups", t => t.volunteerGroupID)
                .Index(t => t.positionLocationID)
                .Index(t => t.volunteerID)
                .Index(t => t.volunteerGroupID);
            
            CreateTable(
                "dbo.PositionLocations",
                c => new
                    {
                        positionLocationID = c.Int(nullable: false, identity: true),
                        posLocationName = c.String(),
                        posLocationStreet1 = c.String(),
                        posLocationStreet2 = c.String(),
                        posLocationCity = c.String(),
                        posLocationState = c.String(),
                        posLocationZip = c.String(),
                        posLocationNotes = c.String(),
                    })
                .PrimaryKey(t => t.positionLocationID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionTitle = c.String(),
                        PositionLocation_positionLocationID = c.Int(),
                    })
                .PrimaryKey(t => t.PositionID)
                .ForeignKey("dbo.PositionLocations", t => t.PositionLocation_positionLocationID)
                .Index(t => t.PositionLocation_positionLocationID);
            
            CreateTable(
                "dbo.VolunteerLanguages",
                c => new
                    {
                        volunteerLanguageID = c.Int(nullable: false, identity: true),
                        volunteerID = c.Int(nullable: false),
                        foreignLanguageID = c.Int(nullable: false),
                        volLangFluencyLvl = c.Short(nullable: false),
                        volLangLiteracyLvl = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.volunteerLanguageID)
                .ForeignKey("dbo.ForeignLanguages", t => t.foreignLanguageID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteers", t => t.volunteerID, cascadeDelete: true)
                .Index(t => t.volunteerID)
                .Index(t => t.foreignLanguageID);
            
            CreateTable(
                "dbo.ForeignLanguages",
                c => new
                    {
                        foreignLanguageID = c.Int(nullable: false, identity: true),
                        foreignLangName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.foreignLanguageID);
            
            CreateTable(
                "dbo.VolunteerTrainings",
                c => new
                    {
                        volunteerTrainingID = c.Int(nullable: false, identity: true),
                        volTrnName = c.String(),
                        volTrnDesc = c.String(),
                        volTrnCCSRequired = c.Int(nullable: false),
                        volTrnStateRequired = c.Int(nullable: false),
                        volTrnMonthsValid = c.Short(nullable: false),
                        volTrnBackgroundLvl = c.Short(nullable: false),
                        volTrnMVR = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.volunteerTrainingID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        contactID = c.Int(nullable: false, identity: true),
                        contactTypeID = c.Int(nullable: false),
                        volunteerID = c.Int(),
                        contactInfo = c.String(maxLength: 100),
                        contCanContact = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.contactID)
                .ForeignKey("dbo.ContactTypes", t => t.contactTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteers", t => t.volunteerID)
                .Index(t => t.contactTypeID)
                .Index(t => t.volunteerID);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        contactTypeID = c.Int(nullable: false, identity: true),
                        contTypeName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.contactTypeID);
            
            CreateTable(
                "dbo.GroupContacts",
                c => new
                    {
                        groupContactID = c.Int(nullable: false, identity: true),
                        grpContName = c.String(maxLength: 50),
                        contactTypeID = c.Int(nullable: false),
                        volunteerGroupID = c.Int(),
                        grpContInfo = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.groupContactID)
                .ForeignKey("dbo.ContactTypes", t => t.contactTypeID, cascadeDelete: true)
                .ForeignKey("dbo.VolunteerGroups", t => t.volunteerGroupID)
                .Index(t => t.contactTypeID)
                .Index(t => t.volunteerGroupID);
            
            CreateTable(
                "dbo.VolunteerGroups",
                c => new
                    {
                        volunteerGroupID = c.Int(nullable: false, identity: true),
                        volGrpName = c.String(),
                        volGrpUserName = c.String(),
                        volGrpPasswordHash = c.String(),
                        volGrpAddress1 = c.String(),
                        volGrpAddress2 = c.String(),
                        volGrpState = c.String(),
                        volGrpZip = c.String(),
                        volGrpIsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.volunteerGroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "volunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.HoursWorkeds", "volunteerGroupID", "dbo.VolunteerGroups");
            DropForeignKey("dbo.GroupContacts", "volunteerGroupID", "dbo.VolunteerGroups");
            DropForeignKey("dbo.GroupContacts", "contactTypeID", "dbo.ContactTypes");
            DropForeignKey("dbo.Contacts", "contactTypeID", "dbo.ContactTypes");
            DropForeignKey("dbo.CompletedTrainings", "volunteerTrainingID", "dbo.VolunteerTrainings");
            DropForeignKey("dbo.VolunteerLanguages", "volunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.VolunteerLanguages", "foreignLanguageID", "dbo.ForeignLanguages");
            DropForeignKey("dbo.HoursWorkeds", "volunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.Positions", "PositionLocation_positionLocationID", "dbo.PositionLocations");
            DropForeignKey("dbo.HoursWorkeds", "positionLocationID", "dbo.PositionLocations");
            DropForeignKey("dbo.Volunteers", "ethnicityID", "dbo.Ethnicities");
            DropForeignKey("dbo.CourtOrdereds", "volunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.CompletedTrainings", "volunteerID", "dbo.Volunteers");
            DropIndex("dbo.GroupContacts", new[] { "volunteerGroupID" });
            DropIndex("dbo.GroupContacts", new[] { "contactTypeID" });
            DropIndex("dbo.Contacts", new[] { "volunteerID" });
            DropIndex("dbo.Contacts", new[] { "contactTypeID" });
            DropIndex("dbo.VolunteerLanguages", new[] { "foreignLanguageID" });
            DropIndex("dbo.VolunteerLanguages", new[] { "volunteerID" });
            DropIndex("dbo.Positions", new[] { "PositionLocation_positionLocationID" });
            DropIndex("dbo.HoursWorkeds", new[] { "volunteerGroupID" });
            DropIndex("dbo.HoursWorkeds", new[] { "volunteerID" });
            DropIndex("dbo.HoursWorkeds", new[] { "positionLocationID" });
            DropIndex("dbo.CourtOrdereds", new[] { "volunteerID" });
            DropIndex("dbo.Volunteers", new[] { "ethnicityID" });
            DropIndex("dbo.CompletedTrainings", new[] { "volunteerTrainingID" });
            DropIndex("dbo.CompletedTrainings", new[] { "volunteerID" });
            DropTable("dbo.VolunteerGroups");
            DropTable("dbo.GroupContacts");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.VolunteerTrainings");
            DropTable("dbo.ForeignLanguages");
            DropTable("dbo.VolunteerLanguages");
            DropTable("dbo.Positions");
            DropTable("dbo.PositionLocations");
            DropTable("dbo.HoursWorkeds");
            DropTable("dbo.Ethnicities");
            DropTable("dbo.CourtOrdereds");
            DropTable("dbo.Volunteers");
            DropTable("dbo.CompletedTrainings");
        }
    }
}
