using System;
using System.Collections.Generic;
using CCSVolunteerMVC.Models;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.ViewModels
{
	/// <summary>
	/// This is a view model that takes in a view model that displays the volunteer information in human
	/// readable form and a view model with the result of a search string
	/// </summary>
	public class CombinedSearchViewModel
	{
		public List<Volunteer> volunteer;
		public List<Ethnicity> ethnicity;
		public List<BooleanTitleMatch> IsActive;
		public List<BooleanTitleMatch> courtOrdered;
		public List<BooleanTitleMatch> IsClient;

		public CombinedSearchViewModel() : this(null, null)
		{	}
		public CombinedSearchViewModel(VolunteerViewModel volunteerViewModel, VolunteerSearch volunteerSearch)
		{
			if(volunteerSearch != null)
			{ 
				volunteer = volunteerSearch.Volunteers.ToList();
				ethnicity = new List<Ethnicity>();
				IsActive = new List<BooleanTitleMatch>();
				courtOrdered = new List<BooleanTitleMatch>();
				IsClient = new List<BooleanTitleMatch>();

			foreach (var item in volunteerSearch.Volunteers)
			{
					ethnicity.Add(volunteerViewModel.EthnicityCollection.Where(i => i.ethnicityID == item.ethnicityID).Select(i => i).First());
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
						courtOrdered.Add(new BooleanTitleMatch() { DatabaseBitValue = 0, Value = "No" });
					}
					else
					{
						courtOrdered.Add(new BooleanTitleMatch() { DatabaseBitValue = 1, Value = "Yes" });
					}
				}
			}
		}
	}
}