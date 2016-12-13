using System;
using System.Collections.Generic;
using System.Linq;
using CCSVolunteerMVC.DAL;
using System.Web;
using System.Threading;

namespace CCSVolunteerMVC.Models
{
	/// <summary>
	/// This is a static class that holds all of the users currently clocked in
	/// This allows for the app to keep track during the day
	/// This has many uses throughout the app
	/// </summary>
	public static class CurrentUsers
	{
		private static List<User> _users = new List<User>();
		private static TimeRoundUp _timeRoundUp = new TimeRoundUp();

		public static List<User> Users
		{
			get { return _users; }
			set { _users = value; }
		}

		public static void AddUser(User user)
		{
			if (user != null)
			{
				_users.Add(user);
			}
		}

		public static void RemoveUser(int index)
		{
			if (_users != null)
			{
				_users.RemoveAt(index);
			}
		}
		public static void UpdateGroupTimeOut(int id, string groupName)
		{
			foreach (var item in _users)
			{
				if (item.GroupId == id && item.GroupName == groupName)
				{
					int tempIndex;
					item.ClockOut = DateTime.Now;
					TimeSpan tempSpan = item.ClockOut.Subtract(item.ClockIn);

					TimeSpan roundedHours = _timeRoundUp.RoundTimeSpan(tempSpan, TimeSpan.FromMinutes(15));
					item.HoursWorkedQuantity = (decimal)roundedHours.TotalHours;

					InsertVolunteerInDatabase(item);
					tempIndex = _users.IndexOf(item);
					RemoveUser(tempIndex);
					break;
				}
			}
		}
		public static void UpdateVolunteerTimeOut(int id, string volunteerName)
		{
			foreach (var item in _users)
			{
				if (item.UserId == id && item.GroupName == volunteerName)
				{
					int tempIndex;
					item.ClockOut = DateTime.Now;
					TimeSpan tempSpan = item.ClockOut.Subtract(item.ClockIn);

					TimeSpan roundedHours = _timeRoundUp.RoundTimeSpan(tempSpan, TimeSpan.FromMinutes(15));
					item.HoursWorkedQuantity = (decimal)roundedHours.TotalHours;

					item.HoursWorkedQuantity = (decimal)tempSpan.TotalMinutes;
					InsertVolunteerInDatabase(item);
					tempIndex = _users.IndexOf(item);
					RemoveUser(tempIndex);
					break;
				}
			}
		}
		public static void ClockOutExcessUsers()
		{
			using (CCSContext context = new CCSContext())
			{
				foreach (var item in _users)
				{
					context.HoursWorkeds.Add(new HoursWorked()
					{
						hrsWrkdIDType = item.HoursWorkedType,
						hrsWrkdTimeIn = item.ClockIn,
						hrsWrkdQty = item.HoursWorkedQuantity,
						hrsWrkdTimeOut = item.ClockOut,
						hrsWrkedSchedDate = item.HoursWorkedDate,
						userAcctID = item.UserAccount,
						modifiedOn = item.ModifiedOn,
						volunteerID = item.UserId,
						volunteerGroupID = item.GroupId,
						volunteer = context.Volunteers.Find(item.UserId),
						positionLocationID = item.PositionLocationId
					});
					context.SaveChanges();
				}
			}
			_users.RemoveRange(0, _users.Count());
		}
		public static void InsertVolunteerInDatabase(User user)
		{
			using (CCSContext context = new CCSContext())
			{
				HoursWorked hoursWorked = new HoursWorked()
				{
					hrsWrkdIDType = user.HoursWorkedType,
					hrsWrkdTimeIn = user.ClockIn,
					hrsWrkdQty = user.HoursWorkedQuantity,
					hrsWrkdTimeOut = user.ClockOut,
					hrsWrkedSchedDate = user.HoursWorkedDate,
					userAcctID = user.UserAccount,
					modifiedOn = user.ModifiedOn,
					volunteerID = user.UserId,
					volunteerGroupID = user.GroupId,
					volunteer = context.Volunteers.Find(user.UserId),
					positionLocation = context.PositionLocations.Find(user.PositionKey),
					positionLocationID = user.PositionLocationId
				};
				context.HoursWorkeds.Add(hoursWorked);
				context.SaveChanges();
			}
		}
	}
}