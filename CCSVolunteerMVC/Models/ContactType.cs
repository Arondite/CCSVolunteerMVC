using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CCSVolunteerMVC.Models
{
    public class ContactType
    {
        public int contactTypeID { get; set; }

        [StringLength(20)]
        public string contTypeName { get; set; }

        public virtual ICollection<Contact> contacts { get; set; }
        public virtual ICollection<GroupContact> groupContact { get; set; }
    }
}