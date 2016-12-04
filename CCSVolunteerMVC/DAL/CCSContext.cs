using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CCSVolunteerMVC.Models;

namespace CCSVolunteerMVC.DAL
{
    public class CCSContext : DbContext
    {
        public DbSet<ForeignLanguage> ForeignLanguages { get; set; }
        public DbSet<VolunteerLanguage> VolunteerLanguages { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<GroupContact> GroupContacts { get; set; }
        public DbSet<CourtOrdered> CourtOrdereds { get; set; }
        public DbSet<VolunteerGroup> VolunteerGroups { get; set; }
        public DbSet<PositionLocation> PositionLocations { get; set; }
        public DbSet<HoursWorked> HoursWorkeds { get; set; }
        public DbSet<CompletedTraining> CompletedTrainings {get; set; }
        public DbSet<VolunteerTraining> VolunteerTrainings { get; set; }
		public DbSet<Position> Positions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			//modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			Database.SetInitializer<CCSContext>(new CreateDatabaseIfNotExists<CCSContext>());
		}
    }
}