using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.Data.Models;
using TimeTracking.MvcApplication.Infrastructure;

namespace TimeTracking.MvcApplication.ViewModels
{
	public class TimeEntryViewModel : ViewModelBase
	{
		public TimeEntryViewModel() : base()
		{
			Mode = ViewMode.Add;
		}

		public TimeEntryViewModel(int id) : this()
		{
			Mode = ViewMode.Edit;

			var timeEntry = _repository.GetTimeEntry(id);
			if (timeEntry != null)
				SetTimeEntry(timeEntry);
		}

		public int TimeEntryId { get; set; }

		public bool HasModel { get { return TimeEntryId > 0; } }

		private List<Project> _projects;
		public List<Project> Projects
		{
			get
			{
				if (_projects == null)
					_projects = _repository.GetProjects(_currentUser.UserId);
				return _projects;
			}
		}

		public IEnumerable<SelectListItem> ProjectItems
		{
			get { return new SelectList(Projects, "ProjectId", "Name"); }
		}

		[Display(Name = "Project")]
		[Required(ErrorMessage="Please select a value for 'Project'")]
		public int? ProjectId { get; set; }

		private List<ProjectTask> _projectTasks;
		public List<ProjectTask> ProjectTasks
		{
			get
			{
				if (_projectTasks == null)
				{
					// give preference to the project ID property if it has a value
					// otherwise grab the first project's ID (as long as we have a collection of projects)
					var projectId = ProjectId;
					if (projectId == null && _projects != null && _projects.Count > 0)
						projectId = _projects[0].ProjectId;

					if (projectId != null)
						_projectTasks = _repository.GetProjectTasks(projectId.Value);
				}
				
				return _projectTasks;
			}
		}

		public string ProjectTasksJson
		{
			get
			{
				var projectTasksJson = string.Empty;
				var projectTasks = ProjectTasks;
				if (projectTasks != null && projectTasks.Count > 0)
				{
					projectTasksJson = JsonConvert.SerializeObject(projectTasks
						.Select(pt => new { ProjectTaskId = pt.ProjectTaskId, Name = pt.Name, Billable = pt.Billable })
						.ToList());
				}
				return projectTasksJson;
			}
		}

		[Display(Name = "Project Task")]
		[Required(ErrorMessage = "Please select a value for 'Task'")]
		public int? ProjectTaskId { get; set; }

		[Display(Name = "Billable?")]
		public bool Billable { get; set; }

		[Display(Name = "Time In")]
		[DataType(DataType.Date)]
		public DateTime? TimeInDate { get; set; }

		[DataType(DataType.Time)]
		[DisplayFormat(DataFormatString = "{0:hh\\:mm tt}", ApplyFormatInEditMode = true)]
		public DateTime? TimeInTime { get; set; }

		public DateTime? TimeIn
		{
			get
			{
				var timeInDate = TimeInDate;
				var timeInTime = TimeInTime;
				if (timeInDate != null && timeInTime != null)
				{
					return timeInDate.Value.Add(timeInTime.Value.TimeOfDay);
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
		[DisplayFormat(DataFormatString = "{0:hh\\:mm tt}", ApplyFormatInEditMode = true)]
		public DateTime? TimeOutTime { get; set; }

		public DateTime? TimeOut
		{
			get
			{
				var timeOutDate = TimeOutDate;
				var timeOutTime = TimeOutTime;
				if (timeOutDate != null && timeOutTime != null)
				{
					return timeOutDate.Value.Add(timeOutTime.Value.TimeOfDay);
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

		public void SetTimeEntry(TimeEntry timeEntry)
		{
			TimeEntryId = timeEntry.TimeEntryId;
			ProjectId = timeEntry.ProjectTask.ProjectId;
			ProjectTaskId = timeEntry.ProjectTaskId;
			Billable = timeEntry.Billable;

			var timeIn = _currentUser.User.ConvertUtcToLocalTime(timeEntry.TimeInUtc);
			TimeInDate = timeIn.Date;
			TimeInTime = new DateTime(timeIn.TimeOfDay.Ticks);

			var timeOutUtc = timeEntry.TimeOutUtc;
			if (timeOutUtc != null)
			{
				var timeOut = _currentUser.User.ConvertUtcToLocalTime(timeOutUtc.Value);
				TimeOutDate = timeOut.Date;
				TimeOutTime = new DateTime(timeOut.TimeOfDay.Ticks);
			}

			Comment = timeEntry.Comment;
		}

		public TimeEntry GetTimeEntry()
		{
			// If we are ading a new record, then time in could be null.
			// If it is, go ahead and set a default value.
			if (TimeIn == null)
			{
				var timeIn = _currentUser.User.ConvertUtcToLocalTime(DateTime.UtcNow);
				TimeInDate = timeIn.Date;
				TimeInTime = new DateTime(timeIn.TimeOfDay.Ticks);
			}

			return new TimeEntry()
			{
				TimeEntryId = this.TimeEntryId,
				UserId = _currentUser.User.UserId,
				ProjectTaskId = this.ProjectTaskId.Value,
				Billable = this.Billable,
				TimeInUtc = _currentUser.User.ConvertLocalTimeToUtc(this.TimeIn.Value),
				TimeOutUtc = this.TimeOut != null ?
					_currentUser.User.ConvertLocalTimeToUtc(this.TimeOut.Value) :
					(DateTime?)null,
				Comment = this.Comment
			};
		}

		public ActionResult Save()
		{
			var timeEntry = GetTimeEntry();
			_repository.SaveTimeEntry(timeEntry);

			// redirect to the "time in" date
			return new RedirectToRouteResult("Date", new System.Web.Routing.RouteValueDictionary(
				new { date = TimeInDate.Value.ToString("yyyy-MM-dd") }));
		}
	}
}