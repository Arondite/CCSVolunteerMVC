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

		public decimal? individualHoursOgden { get; set; }
		public decimal? individualHoursSaltLake { get; set; }

		public decimal? groupHoursOgden { get; set; }
		public decimal? groupHoursSaltLake { get; set; }
		[Required]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime startingDate { get; set; }
		[Required]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

		public DateTime endingDate { get; set; }


	}
}