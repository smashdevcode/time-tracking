using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;

namespace TimeTracking.Data
{
	public class Context : DbContext
	{
		public Context()
			: base(nameOrConnectionString: "TimeTrackingContext")
		{
		}

		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectTask> ProjectTasks { get; set; }
		public DbSet<TimeEntry> TimeEntries { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
