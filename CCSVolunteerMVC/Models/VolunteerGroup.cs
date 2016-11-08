using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
    public class VolunteerGroup
    {
        public int volunteerGroupID { get; set; }

        public string volGrpName { get; set; }
        public string volGrpUserName { get; set; }
        public string volGrpPasswordHash { get; set; }
        public string volGrpAddress1 { get; set; }
        public string volGrpAddress2 { get; set; }
        public string volGrpState { get; set; }
        public string volGrpZip { get; set; }
        public int volGrpIsActive { get; set; }
        public virtual ICollection<HoursWorked> hoursWorked { get; set; }
        public virtual ICollection<GroupContact> groupContacts { get; set; }
    }
}