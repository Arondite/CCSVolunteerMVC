using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	public class User
	{
		public int UserId { get; set; }
		public int GroupId { get; set; }
		public int PositionKey { get; set; }
		public int UserAccount { get; set; }
		public DateTime HoursWorkedDate { get; set; }
		public DateTime ClockIn { get; set; }
		public DateTime ClockOut { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string HoursWorkedType { get; set; }
		public decimal HoursWorkedQuantity { get; set; }
		public User(int userId, int groupId, int positionKey, int userAccount )
		{
			UserId = userId;
			GroupId = groupId;
			PositionKey = positionKey;
			UserAccount = userAccount;
			HoursWorkedDate = DateTime.Now.Date;
			ClockIn = DateTime.UtcNow;
			ClockOut = DateTime.UtcNow.AddHours(1);
			ModifiedOn = DateTime.Now.Date;
			HoursWorkedType = "A";
			HoursWorkedQuantity = 1;
		}
	}
}