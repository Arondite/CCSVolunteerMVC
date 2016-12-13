using CCSVolunteerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CCSVolunteerMVC.ViewModels
{
	public class HoursByDayDetailViewModel
	{
		public DateTime hoursWorkedTimeIn { get; set; }
		public DateTime hoursWorkedTimeOut { get; set; }
		public decimal hoursWrkedQty { get; set; }
		public string volunteerGroupName { get; set; }
		public string volFirstName { get; set; }
		public string volLastName { get; set; }

		public DateTime date { get; set; }
	}
}