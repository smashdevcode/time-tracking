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
		public DateTime TimeIn { get; set; }
		public DateTime? TimeOut { get; set; }
		public string Comment { get; set; }

		public User User { get; set; }
		public ProjectTask ProjectTask { get; set; }
	}
}
