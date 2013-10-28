using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Models
{
	public class TimeEntry
	{
		public int TimeEntryId { get; set; }
		public int UserId { get; set; }
		public int ProjectTaskId { get; set; }
		public bool Billable { get; set; }
		public DateTime TimeInUtc { get; set; }
		public DateTime? TimeOutUtc { get; set; }
		public TimeSpan TotalTime
		{
			get
			{
				var timeOutUtc = TimeOutUtc ?? DateTime.UtcNow;
				if (timeOutUtc >= TimeInUtc)
					return timeOutUtc - TimeInUtc;
				else
					return new TimeSpan();
			}
		}
		public string TotalTimeDisplay
		{
			get
			{
				return Math.Round(TotalTime.TotalHours, 2).ToString();
			}
		}
		public TimeSpan TotalBillableTime
		{
			get
			{
				return Billable ? TotalTime : new TimeSpan();
			}
		}
		public string TotalBillableTimeDisplay
		{
			get
			{
				return Math.Round(TotalBillableTime.TotalHours, 2).ToString();
			}
		}
		public string Comment { get; set; }

		public User User { get; set; }
		public ProjectTask ProjectTask { get; set; }
	}
}
