namespace CCSVolunteerMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using CCSVolunteerMVC.Models;
	using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CCSVolunteerMVC.DAL.CCSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CCSVolunteerMVC.DAL.CCSContext context)
        {
			//var ethnicity = new List<Ethnicity>()
			//{
			//		new Ethnicity(){ ethnicityID = 1, ethName = "other"},
			//		new Ethnicity(){ ethnicityID = 2, ethName = "white"},
			//		new Ethnicity(){ ethnicityID = 3, ethName = "black or african-american"},
			//		new Ethnicity(){ ethnicityID = 4, ethName = "asian"},
			//		new Ethnicity(){ ethnicityID = 5, ethName = "hispanic"},
			//		new Ethnicity(){ ethnicityID = 6, ethName = "american indian or alaskan native"},
			//		new Ethnicity(){ ethnicityID = 7, ethName = "native hawaiian or pacific islander"}
			//	};
			//ethnicity.ForEach(e => context.Ethnicities.Add(e));
			//context.SaveChanges();

		}

	}
}
