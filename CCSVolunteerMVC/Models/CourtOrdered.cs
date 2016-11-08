using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CCSVolunteerMVC.Models
{
    public class CourtOrdered
    {
        public int courtOrderedID { get; set; }
        public int? volunteerID { get; set; }
        public virtual Volunteer volunteer { get; set; }

        [StringLength(15)]
        public string crtOrderCaseNumber { get; set; }
        public int crtOrderedHoursRequired { get; set; }

        [Display(Name = "Court Ordered Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime crtOrderedStartDate { get; set; }

        public int crtOrderedSexOrViolentCrime { get; set; }
        public int crtOrderedOneMonthLimit { get; set; }
    }
}