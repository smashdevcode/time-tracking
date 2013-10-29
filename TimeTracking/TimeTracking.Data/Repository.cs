using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;
using System.Data.Entity;

namespace TimeTracking.Data
{
	public class Repository : IRepository
	{
		private Context _context;

		public Repository()
		{
			_context = new Context();
		}

		public User GetUser(int userId)
		{
			return _context.Users
				.Where(u => u.UserId == userId)
				.FirstOrDefault();
		}

		public List<Project> GetProjects(int userId)
		{
			return _context.Projects
				.Where(p => p.UserId == userId)
				.OrderBy(p => p.Name)
				.ToList();
		}

		public List<ProjectTask> GetProjectTasks(int projectId)
		{
			return _context.ProjectTasks
				.Where(pt => pt.ProjectId == projectId)
				.OrderBy(pt => pt.Name)
				.ToList();
		}

		public TimeEntry GetTimeEntry(int timeEntryId)
		{
			return _context.TimeEntries
				.Include(te => te.ProjectTask)
				.Where(te => te.TimeEntryId == timeEntryId).FirstOrDefault();
		}

		public List<TimeEntry> GetTimeEntries(DateTime date, User user)
		{
			var dateUtcStart = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date, user.TimeZoneId, "UTC");
			var dateUtcEnd = dateUtcStart.AddDays(1);

			return _context.TimeEntries
				.Include("ProjectTask")
				.Include("ProjectTask.Project")
				.Where(te => te.UserId == user.UserId && 
					te.TimeInUtc >= dateUtcStart && te.TimeInUtc < dateUtcEnd)
				.OrderBy(te => te.TimeInUtc)
				.ToList();
		}

		public void SaveTimeEntry(TimeEntry timeEntry)
		{
			// if there's a time entry that doesn't have a time out value
			// then update it to the new time entry's time in value
			var lastTimeEntry = (from te in _context.TimeEntries
								where te.TimeEntryId != timeEntry.TimeEntryId && te.TimeOutUtc == null
								orderby te.TimeInUtc descending
								select te).FirstOrDefault();
			if (lastTimeEntry != null)
				lastTimeEntry.TimeOutUtc = timeEntry.TimeInUtc;
				
			if (timeEntry.TimeEntryId > 0)
				_context.Entry(timeEntry).State = System.Data.Entity.EntityState.Modified;
			else
				_context.TimeEntries.Add(timeEntry);

			_context.SaveChanges();
		}

		public void DeleteTimeEntry(int timeEntryId)
		{
			var timeEntry = new TimeEntry() { TimeEntryId = timeEntryId };
			_context.Entry(timeEntry).State = System.Data.Entity.EntityState.Deleted;

			_context.SaveChanges();
		}

	}
}
