using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	/// <summary>
	/// This is a class that is used for storing the current volunteers at the station
	/// This is the basic model that is needed to write to the database
	/// </summary>
	public class User
	{
		TimeRoundUp _timeRoundUp = new TimeRoundUp();
		public int UserId { get; set; }
		public int GroupId { get; set; }
		public int PositionLocationId { get; set; }
		public int PositionKey { get; set; }
		public int UserAccount { get; set; }
		public DateTime HoursWorkedDate { get; set; }
		public DateTime ClockIn { get; set; }
		public DateTime ClockOut { get; set; }
		public DateTime ModifiedOn { get; set; }
		public string HoursWorkedType { get; set; }
		public decimal HoursWorkedQuantity { get; set; }
		public string GroupName { get; set; }
		public User(int userId, int groupId, int positionKey, int userAccount, string groupName, int positionLocationId)
		{
			UserId = userId;
			GroupId = groupId;
			PositionKey = positionKey;
			UserAccount = userAccount;
			GroupName = groupName;
			HoursWorkedDate = DateTime.Now.Date;
			ClockIn = DateTime.Now;
			ClockOut = DateTime.Now.AddHours(1);
			ModifiedOn = DateTime.UtcNow;
			HoursWorkedType = "A";
			HoursWorkedQuantity = 1;
			PositionLocationId = positionLocationId;
		}
	}
}