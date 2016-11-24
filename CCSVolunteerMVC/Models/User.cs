using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	public class User
	{
		TimeRoundUp _timeRoundUp = new TimeRoundUp();
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
		public string GroupName { get; set; }
		public User(int userId, int groupId, int positionKey, int userAccount, string groupName )
		{
			UserId = userId;
			GroupId = groupId;
			PositionKey = positionKey;
			UserAccount = userAccount;
			GroupName = groupName;
			HoursWorkedDate = DateTime.Now.Date;
			ClockIn = _timeRoundUp.RoundUp(DateTimeOffset.Now, TimeSpan.FromMinutes(15));
			ClockOut = _timeRoundUp.RoundUp(DateTimeOffset.Now, TimeSpan.FromMinutes(15)).AddHours(1);
			ModifiedOn = DateTime.UtcNow;
			HoursWorkedType = "A";
			HoursWorkedQuantity = 1;
		}
	}
}