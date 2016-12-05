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
		
		}
	}
}
