using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	public class WorkDate
	{
		[DataType(DataType.Date)]
		public DateTime day { get; set; }

		public decimal individualHours { get; set; }
		public decimal groupHours { get; set; }
	}
}