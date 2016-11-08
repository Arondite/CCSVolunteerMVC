using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CCSVolunteerMVC.Models
{
    public class HoursWorked
    {
        public int hoursWorkedID { get; set; }
        public int positionLocationID { get; set; }
        public virtual PositionLocation positionLocation { get; set; }

        [StringLength(1)]
        [Display(Name = "Hours Worked ID Type")]

        public string hrsWrkdIDType { get; set; }


        [Display(Name = "Hours Worked Time In")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:hh\-mm}", ApplyFormatInEditMode = true)]
        public DateTime hrsWrkdTimeIn { get; set; }

        [Display(Name = "Hours Worked Time Out")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:hh\-mm}", ApplyFormatInEditMode = true)]
        public DateTime hrsWrkdTimeOut { get; set; }
        public int userAcctID { get; set; }
        //todo find out what object to tie to userAcctID for code first


        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime modifiedOn { get; set; }


        [Display(Name = "Hours Worked Schedule Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime hrsWrkedSchedDate { get; set; }
        public int volunteerID { get; set; }
        public virtual Volunteer volunteer { get; set; }
        public int volunteerGroupID { get; set; }
        //todo vol group object

        [Display(Name = "Hours Worked Quantity")]
        public decimal hrsWrkdQty { get; set; }

    }
}