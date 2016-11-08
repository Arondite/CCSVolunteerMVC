using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CCSVolunteerMVC.Models
{
    public class GroupContact
    {
        public int groupContactID { get; set; }

        [StringLength(50)]
        public string grpContName { get; set; }

        public int contactTypeID { get; set; }
        public virtual ContactType contactType { get; set; }
        public int? volunteerGroupID { get; set; }
        public virtual VolunteerGroup volunteerGroup { get; set; }

        [StringLength(200)]
        public string grpContInfo { get; set; }
    }
}