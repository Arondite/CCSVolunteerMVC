using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
    public class PositionLocation
    {
        public int positionLocationID { get; set; }
        public string posLocationName { get; set; }

        public string posLocationStreet1 { get; set; }

        public string posLocationStreet2 { get; set; }

        public string posLocationCity { get; set; }
        public string posLocationState { get; set; }
        public string posLocationZip { get; set; }
        public string posLocationNotes { get; set; }

        public virtual ICollection<HoursWorked> hoursWorked { get; set; }
		public virtual ICollection<Position> position { get; set; }

	}
}