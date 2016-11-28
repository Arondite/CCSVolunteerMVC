using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCSVolunteerMVC.Models;

namespace CCSVolunteerMVC.ViewModels
{
	/// <summary>
	/// This is a view model that shows the viewable data of a volunteer and the positions
	/// that the volunteer can choose from
	/// </summary>
	public class VolunteerPositionViewModel
	{
		private VolunteerViewModel _Volunteer;
		private IEnumerable<Position> _Positions;

		public IEnumerable<Position> Positions
		{
			get { return _Positions; }
			set { _Positions = value; }
		}

		public VolunteerViewModel Volunteer
		{
			get { return _Volunteer; }
			set { _Volunteer = value; }
		}

		public VolunteerPositionViewModel() : this(null, null)
		{ }
		public VolunteerPositionViewModel(VolunteerViewModel volunteer, IEnumerable<Position> position)
		{
			Volunteer = volunteer;
			Positions = position;
		}
	}
}