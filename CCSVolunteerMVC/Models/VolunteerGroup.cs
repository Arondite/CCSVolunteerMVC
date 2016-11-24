using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
    public class VolunteerGroup
    {
        public int volunteerGroupID { get; set; }
		[Display(Name = "Group Name")]
        public string volGrpName { get; set; }
		[Display(Name = "User Name")]
        public string volGrpUserName { get; set; }
		[Display(Name = "Group Password")]
        public string volGrpPasswordHash { get; set; }
		[Display(Name = "Address 1")]
        public string volGrpAddress1 { get; set; }
		[Display(Name = "Address 2")]
        public string volGrpAddress2 { get; set; }
		[Display(Name = "State")]
        public string volGrpState { get; set; }
		[Display(Name = "Zip")]
        public string volGrpZip { get; set; }
		[Display(Name = "Active")]
        public int volGrpIsActive { get; set; }
        public virtual ICollection<HoursWorked> hoursWorked { get; set; }
        public virtual ICollection<GroupContact> groupContacts { get; set; }
    }
}