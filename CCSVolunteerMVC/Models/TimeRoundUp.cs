using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCSVolunteerMVC.Models
{
	/// <summary>
	/// Basic class to have the time rounded for the fifteen minutes
	/// This was customer request.
	/// </summary>
	public class TimeRoundUp
	{
		public DateTime RoundUp(DateTimeOffset dt, TimeSpan d)
		{
			return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
		}

		public TimeSpan RoundTimeSpan(TimeSpan span, TimeSpan roundingTimeSpan)
		{
			long originalTicks = roundingTimeSpan.Ticks;
			long roundedTicks = (long)(Math.Round((double)span.Ticks / originalTicks) * originalTicks);
			TimeSpan result = new TimeSpan(roundedTicks);
			return result;
		}
	}
}