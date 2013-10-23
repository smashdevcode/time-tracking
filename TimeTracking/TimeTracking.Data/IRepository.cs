using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;

namespace TimeTracking.Data
{
	public interface IRepository
	{
		User GetUser(int userId);
		List<Project> GetProjects(int userId);
		List<TimeEntry> GetTimeEntries(DateTime date, User user);
	}
}
