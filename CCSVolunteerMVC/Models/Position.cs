using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	public class Position
	{
		public int PositionID { get; set; }
		public string PositionTitle { get; set; }
		public virtual PositionLocation PositionLocation { get; set; }
	}
}