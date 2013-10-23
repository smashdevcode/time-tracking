using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TimeTracking.Data.Models;

namespace TimeTracking.MvcApplication.ViewModels
{
	public class TimeEntryAddViewModel
	{
		public TimeEntryAddViewModel()
		{
			// TODO setup collections??? how to also enable ajax calls??? see book example...
			// setup partial method that renders select input element???

			// TODO set property values
		}

		public List<Project> Projects { get; set; }

		[Required(ErrorMessage="Please select a value for 'Project'")]
		public int? ProjectId { get; set; }

		[Required(ErrorMessage = "Please select a value for 'Task'")]
		public int? ProjectTaskId { get; set; }

		public bool Billable { get; set; }

		[DataType(DataType.Date)]
		public DateTime? TimeInDate { get; set; }

		[DataType(DataType.Time)]
		public TimeSpan? TimeInTime { get; set; }

		[DataType(DataType.Date)]
		public DateTime? TimeOutDate { get; set; }

		[DataType(DataType.Time)]
		public TimeSpan? TimeOutTime { get; set; }

		[DataType(DataType.MultilineText)]
		public string Comment { get; set; }

		// TODO setup model level validations
		// TODO validate that if a date or time is provided that both are provided???
		// TODO validate that the time out doesn't come before time in
		// TODO require the comment if the task requires a comment

		public TimeEntry GetTimeEntry()
		{
			var timeEntry = new TimeEntry();




			return timeEntry;
		}
	}
}