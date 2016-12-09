using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CCSVolunteerMVC.DAL;
using System.Web;

namespace CCSVolunteerMVC.Models
{
 
    public class Volunteer
    {
		private string _VolPin;

		public int volunteerID { get; set; }
		[Display(Name = "First Name")]
        public string volFirstName{ get; set;}
		[Display(Name = "Last Name")]
		public string volLastName { get; set; }
		[Display(Name = "Date of Birth")]
		[DataType(DataType.Date)]
		public DateTime volDOB { get; set; }
		[Display(Name = "Volunteer's Pin")]
        public string volPin
		{
			get
			{
				int tempPin;
				int.TryParse(_VolPin, out tempPin);
				if (tempPin > 0)
				{
					return _VolPin;
				}
				else
				{
					string pinValue = null;
					string tempStringPin = volDOB.ToString();
					string[] pinArr = tempStringPin.Split('/');
					pinArr[2] = pinArr[2].Split(' ').ElementAt(0);
					pinArr[2] = pinArr[2].Substring(2, 2);
					if (pinArr[0].Length == 1)
					{
						pinArr[0] = "0" + pinArr[0];
					}
					if (pinArr[1].Length == 1)
					{
						pinArr[1] = "0" + pinArr[1];
					}
					foreach (var item in pinArr)
					{
						pinValue += item;
					}
					if (int.TryParse(pinValue, out tempPin))
					{
						//return _VolPin;
						return pinValue;
					}
					return null;
				}
			}
			set
			{
				_VolPin = value;
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
		[Display(Name = "Ethnicity")]
        public virtual int ethnicityID { get; set; }
        public virtual Ethnicity ethnicity { get; set; }
		[Display(Name = "Client")]
        public byte volsClient { get; set; }
		[Display(Name = "Active")]
        public byte volsActive { get; set; }
        public virtual ICollection<VolunteerLanguage> volunteerLanguages { get; set; }
        public virtual ICollection<CompletedTraining> completedTrainings { get; set; }
        public virtual ICollection<HoursWorked> hoursWorked { get; set; }

    }
}