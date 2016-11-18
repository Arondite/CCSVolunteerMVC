using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCSVolunteerMVC.Models;

namespace CCSVolunteerMVC.ViewModels
{
	public class VolunteerSearch
	{
		public IEnumerable<Volunteer> Volunteers { get; set; }
		public VolunteerSearch() : this(null, null)
		{	}
		public VolunteerSearch(string searchString, IEnumerable<Volunteer> volunteers)
		{
			if(!string.IsNullOrWhiteSpace(searchString))
			{ 
				var inputs = searchString.Split(' ');
				if (inputs.Length == 2)
				{
					var firstIndex = inputs[0].ToString();
					var secondIndex = inputs[1].ToString();
					Volunteers = volunteers.Where(v => v.volFirstName.Contains(firstIndex) &&  v.volLastName.Contains(secondIndex)).Select(v => v).ToList(); 
				}
				else if (inputs.Length == 1)
				{
					var firstIndex = inputs[0].ToString();
					Volunteers = volunteers.Where(v => v.volFirstName.Contains(firstIndex) || v.volLastName.Contains(firstIndex)).Select(v => v).ToList();
				}
			}
		}
	}
}