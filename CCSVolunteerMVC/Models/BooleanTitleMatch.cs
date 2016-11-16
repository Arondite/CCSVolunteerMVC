using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
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