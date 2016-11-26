using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCSVolunteerMVC.Models;

namespace CCSVolunteerMVC.ViewModels
{
	public class VolunteerPositionViewModel
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


		public VolunteerPositionViewModel() : this(null, null)
		{ }
		public VolunteerPositionViewModel(VolunteerGroup volunteer, IEnumerable<Position> position)
		{
			Volunteer = volunteer;
			Position = position;
		}
	}
}