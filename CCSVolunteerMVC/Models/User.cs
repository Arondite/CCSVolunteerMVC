using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string HoursWorkedType { get; set; }
		public DateTime ClockIn { get; set; }
		public DateTime ClockOut { get; set; }
		public DateTime ModifiedOn { get; set; }
		
	}
}