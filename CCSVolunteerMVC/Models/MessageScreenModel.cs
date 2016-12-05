using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	public class MessageScreenModel
	{
		public Volunteer Volunteer { get; set; }
		public VolunteerGroup VolunteerGroup { get; set; }
		public int MyProperty { get; set; }
		public MessageScreenModel() 
		{ }
	}
}