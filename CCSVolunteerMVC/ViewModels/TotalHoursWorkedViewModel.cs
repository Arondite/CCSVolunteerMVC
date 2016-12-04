using CCSVolunteerMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.ViewModels
{
	public class TotalHoursWorkedViewModel
	{
		public List<WorkDate> workDates { get; set; }

		[DataType(DataType.Date)]
		public DateTime startingDay { get; set; }

		public DateTime endingDay { get; set; }

		public decimal individualTotal { get; set; }
		public decimal groupTotal { get; set; }
	}
}