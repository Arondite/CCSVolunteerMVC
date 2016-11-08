using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
    public class VolunteerLanguage
    {
        public int volunteerLanguageID { get; set; }
        public virtual int volunteerID { get; set; }
        public virtual Volunteer volunteer { get; set; }
        public virtual int foreignLanguageID { get; set; }
        public virtual ForeignLanguage foreignLanguage { get; set; }
        public short volLangFluencyLvl { get; set; }
        public short volLangLiteracyLvl { get; set; }
    
    }
}