namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialseed1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompletedTraining",
                c => new
                    {
                        completedTrainingID = c.Int(nullable: false, identity: true),
                        volunteerID = c.Int(nullable: false),
                        volunteerTrainingID = c.Int(nullable: false),
                        cmpTrnDate = c.DateTime(nullable: false),
                        cmpTrnComments = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.completedTrainingID)
                .ForeignKey("dbo.Volunteer", t => t.volunteerID, cascadeDelete: true)
                .ForeignKey("dbo.VolunteerTraining", t => t.volunteerTrainingID, cascadeDelete: true)
                .Index(t => t.volunteerID)
                .Index(t => t.volunteerTrainingID);
            
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        volunteerID = c.Int(nullable: false, identity: true),
                        volFirstName = c.String(),
                        volLastName = c.String(),
                        volDOB = c.DateTime(nullable: false),
                        volPin = c.Int(nullable: false),
                        volGender = c.String(),
                        volJoinDate = c.DateTime(nullable: false),
                        volsCourtOrdered = c.Int(nullable: false),
                        ethID = c.Int(),
                        volsClient = c.Byte(nullable: false),
                        volsActive = c.Byte(nullable: false),
                        ethnicity_ethnicityID = c.Int(),
                    })
                .PrimaryKey(t => t.volunteerID)
                .ForeignKey("dbo.Ethnicity", t => t.ethnicity_ethnicityID)
                .Index(t => t.ethnicity_ethnicityID);
            
            CreateTable(
                "dbo.CourtOrdered",
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
                .ForeignKey("dbo.Volunteer", t => t.volunteerID)
                .Index(t => t.volunteerID);
            
            CreateTable(
                "dbo.Ethnicity",
                c => new
                    {
                        ethnicityID = c.Int(nullable: false, identity: true),
                        ethName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ethnicityID);
            
            CreateTable(
                "dbo.HoursWorked",
                c => new
                    {
                        hoursWorkedID = c.Int(nullable: false, identity: true),
                        posLocationID = c.Int(nullable: false),
                        hrsWrkdIDType = c.String(maxLength: 1),
                        hrsWrkdTimeIn = c.DateTime(nullable: false),
                        hrsWrkdTimeOut = c.DateTime(nullable: false),
                        userAcctID = c.Int(nullable: false),
                        modifiedOn = c.DateTime(nullable: false),
                        hrsWrkedSchedDate = c.DateTime(nullable: false),
                        volunteerID = c.Int(nullable: false),
                        volunteerGroupID = c.Int(nullable: false),
                        hrsWrkdQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        positionLocation_positionLocationID = c.Int(),
                    })
                .PrimaryKey(t => t.hoursWorkedID)
                .ForeignKey("dbo.PositionLocation", t => t.positionLocation_positionLocationID)
                .ForeignKey("dbo.Volunteer", t => t.volunteerID, cascadeDelete: true)
                .ForeignKey("dbo.VolunteerGroup", t => t.volunteerGroupID, cascadeDelete: true)
                .Index(t => t.volunteerID)
                .Index(t => t.volunteerGroupID)
                .Index(t => t.positionLocation_positionLocationID);
            
            CreateTable(
                "dbo.PositionLocation",
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
                "dbo.VolunteerLanguage",
                c => new
                    {
                        volunteerLanguageID = c.Int(nullable: false, identity: true),
                        volunteerID = c.Int(nullable: false),
                        foreignLanguageID = c.Int(nullable: false),
                        volLangFluencyLvl = c.Short(nullable: false),
                        volLangLiteracyLvl = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.volunteerLanguageID)
                .ForeignKey("dbo.ForeignLanguage", t => t.foreignLanguageID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteer", t => t.volunteerID, cascadeDelete: true)
                .Index(t => t.volunteerID)
                .Index(t => t.foreignLanguageID);
            
            CreateTable(
                "dbo.ForeignLanguage",
                c => new
                    {
                        foreignLanguageID = c.Int(nullable: false, identity: true),
                        foreignLangName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.foreignLanguageID);
            
            CreateTable(
                "dbo.VolunteerTraining",
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
                "dbo.Contact",
                c => new
                    {
                        contactID = c.Int(nullable: false, identity: true),
                        contactTypeID = c.Int(nullable: false),
                        volunteerID = c.Int(),
                        contactInfo = c.String(maxLength: 100),
                        contCanContact = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.contactID)
                .ForeignKey("dbo.ContactType", t => t.contactTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteer", t => t.volunteerID)
                .Index(t => t.contactTypeID)
                .Index(t => t.volunteerID);
            
            CreateTable(
                "dbo.ContactType",
                c => new
                    {
                        contactTypeID = c.Int(nullable: false, identity: true),
                        contTypeName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.contactTypeID);
            
            CreateTable(
                "dbo.GroupContact",
                c => new
                    {
                        groupContactID = c.Int(nullable: false, identity: true),
                        grpContName = c.String(maxLength: 50),
                        contactTypeID = c.Int(nullable: false),
                        volunteerGroupID = c.Int(),
                        grpContInfo = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.groupContactID)
                .ForeignKey("dbo.ContactType", t => t.contactTypeID, cascadeDelete: true)
                .ForeignKey("dbo.VolunteerGroup", t => t.volunteerGroupID)
                .Index(t => t.contactTypeID)
                .Index(t => t.volunteerGroupID);
            
            CreateTable(
                "dbo.VolunteerGroup",
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
            DropForeignKey("dbo.Contact", "volunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.HoursWorked", "volunteerGroupID", "dbo.VolunteerGroup");
            DropForeignKey("dbo.GroupContact", "volunteerGroupID", "dbo.VolunteerGroup");
            DropForeignKey("dbo.GroupContact", "contactTypeID", "dbo.ContactType");
            DropForeignKey("dbo.Contact", "contactTypeID", "dbo.ContactType");
            DropForeignKey("dbo.CompletedTraining", "volunteerTrainingID", "dbo.VolunteerTraining");
            DropForeignKey("dbo.VolunteerLanguage", "volunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.VolunteerLanguage", "foreignLanguageID", "dbo.ForeignLanguage");
            DropForeignKey("dbo.HoursWorked", "volunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.HoursWorked", "positionLocation_positionLocationID", "dbo.PositionLocation");
            DropForeignKey("dbo.Volunteer", "ethnicity_ethnicityID", "dbo.Ethnicity");
            DropForeignKey("dbo.CourtOrdered", "volunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.CompletedTraining", "volunteerID", "dbo.Volunteer");
            DropIndex("dbo.GroupContact", new[] { "volunteerGroupID" });
            DropIndex("dbo.GroupContact", new[] { "contactTypeID" });
            DropIndex("dbo.Contact", new[] { "volunteerID" });
            DropIndex("dbo.Contact", new[] { "contactTypeID" });
            DropIndex("dbo.VolunteerLanguage", new[] { "foreignLanguageID" });
            DropIndex("dbo.VolunteerLanguage", new[] { "volunteerID" });
            DropIndex("dbo.HoursWorked", new[] { "positionLocation_positionLocationID" });
            DropIndex("dbo.HoursWorked", new[] { "volunteerGroupID" });
            DropIndex("dbo.HoursWorked", new[] { "volunteerID" });
            DropIndex("dbo.CourtOrdered", new[] { "volunteerID" });
            DropIndex("dbo.Volunteer", new[] { "ethnicity_ethnicityID" });
            DropIndex("dbo.CompletedTraining", new[] { "volunteerTrainingID" });
            DropIndex("dbo.CompletedTraining", new[] { "volunteerID" });
            DropTable("dbo.VolunteerGroup");
            DropTable("dbo.GroupContact");
            DropTable("dbo.ContactType");
            DropTable("dbo.Contact");
            DropTable("dbo.VolunteerTraining");
            DropTable("dbo.ForeignLanguage");
            DropTable("dbo.VolunteerLanguage");
            DropTable("dbo.PositionLocation");
            DropTable("dbo.HoursWorked");
            DropTable("dbo.Ethnicity");
            DropTable("dbo.CourtOrdered");
            DropTable("dbo.Volunteer");
            DropTable("dbo.CompletedTraining");
        }
    }
}
