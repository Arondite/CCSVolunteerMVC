using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
 
    public class Volunteer
    {
		private int _VolPin;
		public int volunteerID { get; set; }
		[Display(Name = "First Name")]
        public string volFirstName{ get; set;}
		[Display(Name = "Last Name")]
		public string volLastName { get; set; }
		[Display(Name = "Date of Birth")]
		[DataType(DataType.Date)]
		public DateTime volDOB { get; set; }
        public int volPin
		{
			get
			{
				if (_VolPin > 0)
				{
					return _VolPin;
				}
				else
				{
					string pinValue = null;
					string tempPin = volDOB.ToString();
					string[] pinArr = tempPin.Split('/');
					pinArr[2] = pinArr[2].Split(' ').ElementAt(0);
					pinArr[2] = pinArr[2].Substring(2, 2);
					if (pinArr[0].Length == 1)
					{
						pinArr[0] = "0" + pinArr[0];
					}
					foreach (var item in pinArr)
					{
						pinValue += item;
					}
					if (int.TryParse(pinValue, out _VolPin))
					{
						return _VolPin;
					}
					return 0;
				}
			}
			set
			{
				volPin = value;
			}
		}
		[Display(Name = "Gender")]
		public string volGender { get; set; }
		[Display(Name = "Join Date")]
		[DataType(DataType.Date)]
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