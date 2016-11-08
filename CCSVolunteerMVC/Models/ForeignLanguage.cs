using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CCSVolunteerMVC.Models
{
    public class ForeignLanguage
    {
        public int foreignLanguageID { get; set; }

        [StringLength(20)]
        public string foreignLangName { get; set; }
        public ICollection<VolunteerLanguage> volunteerLanguages { get; set; }
    }
}