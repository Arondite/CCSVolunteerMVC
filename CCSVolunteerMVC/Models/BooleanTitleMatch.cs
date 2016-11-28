using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	/// <summary>
	/// This is a basic class that will turn database data into viewable data
	/// 1 => true
	/// 0 => false
	/// </summary>
	public class BooleanTitleMatch
	{
		private int _DatabaseBitValue;
		private string _Value;

		public string Value
		{
			get { return _Value; }
			set { _Value = value; }
		}

		public int DatabaseBitValue
		{
			get { return _DatabaseBitValue; }
			set { _DatabaseBitValue = value; }
		}

	}
}