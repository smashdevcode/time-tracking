using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

		public IEnumerable<SelectListItem> ProjectItems
		{
			get { return new SelectList(Projects, "ProjectId", "Name"); }
		}

		[Display(Name = "Project")]
		[Required(ErrorMessage="Please select a value for 'Project'")]
		public int? ProjectId { get; set; }

		// TODO remove???

		//public List<ProjectTask> ProjectTasks { get; set; }

		//public IEnumerable<SelectListItem> ProjectTaskItems
		//{
		//	get { return new SelectList(ProjectTasks, "ProjectTaskId", "Name"); }
		//}

		[Display(Name = "Project Task")]
		[Required(ErrorMessage = "Please select a value for 'Task'")]
		public int? ProjectTaskId { get; set; }

		[Display(Name = "Billable?")]
		public bool Billable { get; set; }

		[Display(Name = "Time In")]
		[DataType(DataType.Date)]
		public DateTime? TimeInDate { get; set; }

		[DataType(DataType.Time)]
		public TimeSpan? TimeInTime { get; set; }

		public DateTime? TimeIn
		{
			get
			{
				var timeInDate = TimeInDate;
				var timeInTime = TimeInTime;
				if (timeInDate != null && timeInTime != null)
				{
					return timeInDate.Value.Add(timeInTime.Value);
				}
				else
				{
					return null;
				}
			}
		}

		[Display(Name = "Time Out")]
		[DataType(DataType.Date)]
		public DateTime? TimeOutDate { get; set; }

		[DataType(DataType.Time)]
		public TimeSpan? TimeOutTime { get; set; }

		public DateTime? TimeOut
		{
			get
			{
				var timeOutDate = TimeOutDate;
				var timeOutTime = TimeOutTime;
				if (timeOutDate != null && timeOutTime != null)
				{
					return timeOutDate.Value.Add(timeOutTime.Value);
				}
				else
				{
					return null;
				}
			}
		}

		[Display(Name = "Comment")]
		[DataType(DataType.MultilineText)]
		public string Comment { get; set; }

		// TODO setup model level validations
		// TODO validate that if a date or time is provided that both are provided???
		// TODO validate that the time out doesn't come before time in
		// TODO require the comment if the task requires a comment

		public TimeEntry GetTimeEntry(User user)
		{
			return new TimeEntry()
			{
				UserId = user.UserId,
				ProjectTaskId = this.ProjectTaskId.Value,
				Billable = this.Billable,
				TimeInUtc = this.TimeIn != null ? 
					TimeZoneInfo.ConvertTimeBySystemTimeZoneId(this.TimeIn.Value, user.TimeZoneId, "UTC") : 
					DateTime.UtcNow,
				TimeOutUtc = this.TimeOut != null ?
					TimeZoneInfo.ConvertTimeBySystemTimeZoneId(this.TimeOut.Value, user.TimeZoneId, "UTC") :
					(DateTime?)null,
				Comment = this.Comment
			};
		}
	}
}