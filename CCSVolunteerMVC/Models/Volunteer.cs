using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
 
    public class Volunteer
    {
        public int volunteerID { get; set; }
        public string volFirstName { get; set; }

        public string volLastName { get; set; }

        public DateTime volDOB { get; set; }
        public int volPin { get; set; }

        public string volGender { get; set; }

        public DateTime volJoinDate { get; set; }

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