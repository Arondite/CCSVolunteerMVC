using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCSVolunteerMVC.Models;

namespace CCSVolunteerMVC.DAL
{
	public class DatabaseHelper
	{
		private CCSContext context = new CCSContext();

		public void WriteUser(User user)
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
				positionLocationID = user.PositionLocationId,
				IsClockedIn = 1
			};
			context.HoursWorkeds.Add(hoursWorked);
			context.SaveChanges();
		}

		public void FindRecentVolunteerUser(User user)
		{
			TimeRoundUp tempTime = new TimeRoundUp();
			var item = context.HoursWorkeds.Where(u => u.volunteerID == user.UserId).Where(u => u.IsClockedIn == 1)
																						.OrderByDescending(i => i.hrsWrkdTimeIn.Year)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Month)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Day)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Hour)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Minute).First();
			if (item != null)
			{
				item.hrsWrkdTimeOut = DateTime.Now;
				item.IsClockedIn = 0;
				item.modifiedOn = DateTime.Now;
				context.SaveChanges();
			}
		}

		public void FindRecentGroupUser(User user)
		{
			TimeRoundUp tempTime = new TimeRoundUp();
			var item = context.HoursWorkeds.Where(u => u.volunteerGroupID == user.GroupId).Where(u => u.IsClockedIn == 1)
																						.OrderByDescending(i => i.hrsWrkdTimeIn.Year)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Month)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Day)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Hour)
																						.ThenByDescending(i => i.hrsWrkdTimeIn.Minute).First();
			if (item != null)
			{
				item.hrsWrkdTimeOut = DateTime.Now;
				item.IsClockedIn = 0;
				item.modifiedOn = DateTime.Now;
				context.SaveChanges();
			}
		}

		public HoursWorked FindTodayEntryOfVolunteer(Volunteer user)
		{
			var count = context.HoursWorkeds.Where(u => u.volunteerID == user.volunteerID).Where(u => u.IsClockedIn == 1)
											.Where(u => u.hrsWrkdTimeIn.Day == DateTime.Now.Day).Where(u => u.hrsWrkdTimeIn.Month == DateTime.Now.Month)
											.OrderByDescending(u => u.hrsWrkdTimeIn).Count();

			if (count > 0)
			{
				return context.HoursWorkeds.Where(u => u.volunteerID == user.volunteerID).Where(u => u.IsClockedIn == 1)
											.Where(u => u.hrsWrkdTimeIn.Day == DateTime.Now.Day).Where(u => u.hrsWrkdTimeIn.Month == DateTime.Now.Month)
											.OrderByDescending(u => u.hrsWrkdTimeIn).First();
			}
			else {
				return null;
			}
		}
		public int CountNumberOfGroupMembers(VolunteerGroup volunteerGroup)
		{
			var count = context.HoursWorkeds.Where(g => g.volunteerGroupID == volunteerGroup.volunteerGroupID).Where(g => g.hrsWrkdTimeIn.Year == DateTime.Now.Year)
													.Where(g => g.hrsWrkdTimeIn.Month == DateTime.Now.Month).Where(g => g.hrsWrkdTimeIn.Day == DateTime.Now.Day)
													.Where(g => g.IsClockedIn == 1).Count();
			return count;
		}

		public List<HoursWorked> CollectionOfGroup(int CollectionCount, User volunteerGroup)
		{
			var groupCollection = context.HoursWorkeds.Where(g => g.volunteerGroupID == volunteerGroup.GroupId).Where(g => g.hrsWrkdTimeIn.Year == DateTime.Now.Year)
													.Where(g => g.hrsWrkdTimeIn.Month == DateTime.Now.Month).Where(g => g.hrsWrkdTimeIn.Day == DateTime.Now.Day)
													.Where(g => g.IsClockedIn == 1).ToList();
			List<HoursWorked> returnedCollection = new List<HoursWorked>();
			if (CollectionCount > groupCollection.Count)
			{
				CollectionCount = groupCollection.Count;
			}
			for (int i = 0; i < CollectionCount; i++)
			{
				returnedCollection.Add(groupCollection.ElementAt(i));
			}
			return returnedCollection;
		}

		public void ClockOutExcessUsers()
		{
			var unclockedUsers = context.HoursWorkeds.Where(g => g.hrsWrkdTimeIn.Year == DateTime.Now.Year).Where(g => g.hrsWrkdTimeIn.Month == DateTime.Now.Month)
													.Where(g => g.hrsWrkdTimeIn.Day == DateTime.Now.Day).Where(g => g.IsClockedIn == 1).ToList();
			foreach (var item in unclockedUsers)
			{
				item.hrsWrkdTimeOut.AddHours(1);
				item.IsClockedIn = 0;
				item.modifiedOn = DateTime.Now;
			}
			context.SaveChanges();
		}
	}
}