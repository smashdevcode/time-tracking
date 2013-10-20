using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracking.Data.Models;
using TimeTracking.MvcApplication.Infrastructure;

namespace TimeTracking.MvcApplication.ViewModels
{
	public class HomeIndexViewModel
	{
		public HomeIndexViewModel(DateTime date, List<TimeEntry> timeEntries)
		{
			Date = date;
			WeekOf = date.GetStartOfWeek();
			TimeEntries = timeEntries;

			var dates = new List<DateTime>();
			for (var i = 0; i < 7; i++)
				dates.Add(WeekOf.AddDays(i));
			Dates = dates;

			PreviousWeek = WeekOf.AddDays(-7);
			NextWeek = WeekOf.AddDays(7);
		}

		public DateTime Date { get; set; }
		public DateTime WeekOf { get; set; }
		public List<DateTime> Dates { get; set; }
		public DateTime PreviousWeek { get; set; }
		public DateTime NextWeek { get; set; }
		public List<TimeEntry> TimeEntries { get; set; }
	}
}