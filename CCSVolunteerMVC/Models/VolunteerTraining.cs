using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
    public class VolunteerTraining
    {
        public int volunteerTrainingID { get; set; }
        public string volTrnName { get; set; }
        public string volTrnDesc { get; set; }
        public int volTrnCCSRequired { get; set; }
        public int volTrnStateRequired { get; set; }
        public short volTrnMonthsValid { get; set; }
        public short volTrnBackgroundLvl { get; set; }
        public int volTrnMVR { get; set; }

        public virtual ICollection<CompletedTraining> completedTrainings { get; set; }
    }
}