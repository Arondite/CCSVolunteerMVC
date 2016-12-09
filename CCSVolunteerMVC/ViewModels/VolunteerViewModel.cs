using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CCSVolunteerMVC.Models;
using CCSVolunteerMVC.DAL;

namespace CCSVolunteerMVC.ViewModels
{
	/// <summary>
	/// Creates multiple collection for display to the user. This is the human 
	/// readable view of a volunteer from the database
	/// </summary>
	public class VolunteerViewModel
	{
		public IEnumerable<Volunteer> Volunteer;
		public IEnumerable<Ethnicity> EthnicityCollection;
		public List<Ethnicity> Ethnicity;
		public List<BooleanTitleMatch> IsClient;
		public List<BooleanTitleMatch> IsActive;
		public List<BooleanTitleMatch> CourtOrdered;
		/// <summary>
		/// Builds a view model that is more comprehendable than basic models
		/// </summary>
		/// <param name="volunteer">All volunteers in the database</param>
		/// <param name="ethnicityCollection">All the entries in the Ethnicity table</param>
		public VolunteerViewModel(IEnumerable<Volunteer> volunteer, IEnumerable<Ethnicity> ethnicityCollection)
		{
			Volunteer = new List<Volunteer>(volunteer);
			EthnicityCollection = new List<Ethnicity>(ethnicityCollection);
			Ethnicity = new List<Ethnicity>();
			IsActive = new List<BooleanTitleMatch>();
			IsClient = new List<BooleanTitleMatch>();
			CourtOrdered = new List<BooleanTitleMatch>();

			//This adds all of the necessary information to convert the database types into Readable 
			//via ViewModel. This will take the bad data from the database and make it useful.
			foreach (var item in Volunteer)
			{
				if (item.ethnicityID != null)
				{
					Ethnicity.Add(EthnicityCollection.Where(i => i.ethnicityID == item.ethnicityID).Select(i => i).First());
					if (item.volsActive == 0)
					{
						IsActive.Add(new BooleanTitleMatch() { DatabaseBitValue = 0, Value = "No" });
					}
					else
					{
						IsActive.Add(new BooleanTitleMatch() { DatabaseBitValue = 1, Value = "Yes" });
					}
					if (item.volsClient == 0)
					{
						IsClient.Add(new BooleanTitleMatch() { DatabaseBitValue = 0, Value = "No" });
					}
					else
					{
						IsClient.Add(new BooleanTitleMatch() { DatabaseBitValue = 1, Value = "Yes" });
					}
					if (item.volsCourtOrdered == 0)
					{
						CourtOrdered.Add(new BooleanTitleMatch() { DatabaseBitValue = 0, Value = "No" });
					}
					else
					{
						CourtOrdered.Add(new BooleanTitleMatch() { DatabaseBitValue = 1, Value = "Yes" });
					}
				}

			}
		}

	}
}
