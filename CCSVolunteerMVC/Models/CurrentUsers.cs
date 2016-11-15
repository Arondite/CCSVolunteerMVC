using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	public static class CurrentUsers
	{
		private static List<User> _users;

		public static List<User> Users
		{
			get { return _users; }
			set { _users = value; }
		}

		public static void AddUser(User user)
		{
			_users.Add(user);
		}

		public static void RemoveUser(int id)
		{
			if(_users.Any(i => i.UserId == id))
			{
				_users.RemoveAll(u => u.UserId == id);
			}
		}
	}
}