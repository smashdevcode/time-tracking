using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;

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
			if (timeEntry.TimeEntryId > 0)
			{
				_context.Entry(timeEntry).State = System.Data.Entity.EntityState.Modified;
			}
			else
			{
				_context.TimeEntries.Add(timeEntry);
			}

			_context.SaveChanges();
		}

	}
}
