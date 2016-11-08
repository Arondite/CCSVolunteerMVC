using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
 
    public class Volunteer
    {
        public int volunteerID { get; set; }
		[Display(Name = "First Name")]
        public string volFirstName { get; set; }
		[Display(Name = "Last Name")]
		public string volLastName { get; set; }
		[Display(Name = "Date of Birth")]
		public DateTime volDOB { get; set; }
        public int volPin { get; set; }
		[Display(Name = "Gender")]
		public string volGender { get; set; }
		[Display(Name = "Join Date")]
		public DateTime volJoinDate { get; set; }
		[Display(Name = "Court Ordered")]
		public int volsCourtOrdered { get; set; }
        public virtual ICollection<CourtOrdered> courtOrdereds { get; set; }

        public virtual int? ethnicityID { get; set; }

        public virtual Ethnicity ethnicity { get; set; }

        public byte volsClient { get; set; }

        public byte volsActive { get; set; }
        public virtual ICollection<VolunteerLanguage> volunteerLanguages { get; set; }

        public virtual ICollection<CompletedTraining> completedTrainings { get; set; }

        public virtual ICollection<HoursWorked> hoursWorked { get; set; }

    }
}