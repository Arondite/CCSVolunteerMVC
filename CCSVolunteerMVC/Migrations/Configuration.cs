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
			var positionsLocation = new List<PositionLocation>()
			{
				new PositionLocation() { positionLocationID = 1, posLocationName = "Salt Lake City", posLocationStreet1 = "", posLocationStreet2 = "", posLocationCity = "Salt Lake City", posLocationState = "Utah", posLocationNotes = "", posLocationZip = "84101" },
				new PositionLocation() { positionLocationID = 2, posLocationName = "Ogden", posLocationStreet1 = "", posLocationStreet2 = "", posLocationCity = "Ogden", posLocationState = "Utah", posLocationNotes = "", posLocationZip = "84201" }
			};
			positionsLocation.ForEach(p => context.PositionLocations.Add(p));
			context.SaveChanges();
		}
	}
}
