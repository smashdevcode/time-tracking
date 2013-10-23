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
		public TimeSpan TotalBillableTime
		{
			get
			{
				return Billable ? TotalTime : new TimeSpan();
			}
		}
		public string Comment { get; set; }

		public User User { get; set; }
		public ProjectTask ProjectTask { get; set; }
	}
}
