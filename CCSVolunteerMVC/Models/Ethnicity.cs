using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCSVolunteerMVC.Models;
using System.ComponentModel.DataAnnotations;


namespace CCSVolunteerMVC.Models
{
    public class Ethnicity
    {
        public int ethnicityID { get; set; }

        [StringLength(50)]
        public string ethName { get; set; }

        public virtual ICollection<Volunteer> volunteers { get; set; }
    }
}