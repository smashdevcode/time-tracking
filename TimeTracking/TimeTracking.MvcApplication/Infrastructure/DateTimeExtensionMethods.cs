using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.MvcApplication.Infrastructure
{
	public static class DateTimeExtensionMethods
	{
		public static DateTime GetStartOfWeek(this DateTime date)
		{
			if (date.DayOfWeek == DayOfWeek.Saturday)
				return date.Date;
			else
				return date.AddDays(((int)date.DayOfWeek + 1) * -1).Date;
		}
	}
}