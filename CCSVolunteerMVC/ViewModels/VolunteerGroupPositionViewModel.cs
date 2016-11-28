using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCSVolunteerMVC.Models;

namespace CCSVolunteerMVC.ViewModels
{
	/// <summary>
	/// This is a view model that takes the VolunteerGroup and the positions that are available
	/// </summary>
	public class VolunteerGroupPositionViewModel
	{
		private VolunteerGroup _Volunteer;
		private IEnumerable<Position> _Position;

		public IEnumerable<Position> Position
		{
			get { return _Position; }
			set { _Position = value; }
		}

		public VolunteerGroup Volunteer
		{
			get { return _Volunteer; }
			set { _Volunteer = value; }
		}


		public VolunteerGroupPositionViewModel() : this(null, null)
		{ }
		public VolunteerGroupPositionViewModel(VolunteerGroup volunteer, IEnumerable<Position> position)
		{
			Volunteer = volunteer;
			Position = position;
		}
	}
}