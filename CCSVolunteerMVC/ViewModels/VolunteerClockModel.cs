using System;
using System.Collections.Generic;
using CCSVolunteerMVC.Models;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.ViewModels
{
	/// <summary>
	/// This is a view model that holds the list of volunteers
	/// </summary>
	public class VolunteerClockModel
	{
		private IEnumerable<Volunteer> _Volunteers;
		private string _Clock;

		public string Clock
		{
			get { return _Clock; }
			set { _Clock = value; }
		}

		public IEnumerable<Volunteer> Volunteers
		{
			get { return _Volunteers; }
			set { _Volunteers = value; }
		}

		public VolunteerClockModel(IEnumerable<Volunteer> volunteers, string clock)
		{
			Clock = clock;
			Volunteers = volunteers.ToList();
		}

	}
}