using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CCSVolunteerMVC.Models
{
    public class Contact
    {
        public int contactID { get; set; }
        public int contactTypeID { get; set; }
        public virtual ContactType contactType { get; set; }

        public int? volunteerID { get; set; }
        public virtual Volunteer volunteer { get; set; }
        
        [StringLength(100)]
        public string contactInfo { get; set; }
        public int contCanContact { get; set; }
    }
}