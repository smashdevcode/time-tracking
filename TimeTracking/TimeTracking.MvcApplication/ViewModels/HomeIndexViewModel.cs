using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.Data.Models;
using TimeTracking.MvcApplication.Infrastructure;

namespace TimeTracking.MvcApplication.ViewModels
{
	public class HomeIndexViewModel : ViewModelBase
	{
		public HomeIndexViewModel(DateTime? date) : base()
		{
			if (date == null)
				date = _currentUser.User.ConvertUtcToLocalTime(DateTime.UtcNow).Date;

			Date = date.Value;
			WeekOf = date.Value.GetStartOfWeek();
			TimeEntries = _repository.GetTimeEntries(date.Value, _currentUser.User);

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

		public string ToLocalDateTimeString(DateTime? utc, string formatString = "hh:mm tt", 
			string defaultString = "N/A")
		{
			if (utc != null)
			{
				return _currentUser.User.ConvertUtcToLocalTime(utc.Value).ToString(formatString);
			}
			else
			{
				return defaultString;
			}
		}
	}
}