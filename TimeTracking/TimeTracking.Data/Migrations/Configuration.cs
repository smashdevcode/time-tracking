using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TimeTracking.Data.Models;

namespace TimeTracking.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
			var user = new User()
			{
				UserId = 1,
				Username = "jamesc",
				Name = "James Churchill",
				Email = "jamesc@csgpro.com",
				TimeZoneId = "Pacific Standard Time"
			};
			context.Users.AddOrUpdate(user);

			AddProject(context, 1, "CIS: Liability & Workers' Comp Claims Management System - Elaboration Phase");
			AddProject(context, 2, "LP: Barcode Scanning App");
			AddProject(context, 3, "McMenamins: MCM-12 Events-Phase 1");
			AddProject(context, 4, "R2C: Tracker-2 Development");
			AddProject(context, 5, "R2C: Tracker-2 Maintenance");
			AddProject(context, 6, "SSII: Managed Services - Web Apps");
			AddProject(context, 7, "CSG: Internal projects - AppDev");

			AddProjectTask(context, 1, 1, true);
			AddProjectTask(context, 2, 2, true);
			AddProjectTask(context, 3, 3, true);
			AddProjectTask(context, 4, 4, true);
			AddProjectTask(context, 5, 5, true);
			AddProjectTask(context, 6, 6, true);
			AddProjectTask(context, 7, 7, false, "Pre Sales");
			AddProjectTask(context, 8, 7, false, "Training/Conference");
			AddProjectTask(context, 9, 7, false, "Travel Time");
			AddProjectTask(context, 10, 7, false, "Research");
			AddProjectTask(context, 11, 7, false, "Practice Development");
			AddProjectTask(context, 12, 7, false, "Practice Administration");
			AddProjectTask(context, 13, 7, false, "Team Meeting");
			AddProjectTask(context, 14, 7, false, "1:1 Team Member Meeting");
        }

		private void AddProject(Context context, int projectId, string name)
		{
			var project = new Project()
			{
				ProjectId = projectId,
				Name = name
			};
			context.Projects.AddOrUpdate(project);
		}
		private void AddProjectTask(Context context, int projectTaskId, int projectId, bool billable, 
			string name = "Default")
		{
			var projectTask = new ProjectTask()
			{
				ProjectTaskId = projectTaskId,
				ProjectId = projectId,
				Billable = billable,
				Name = name
			};
			context.ProjectTasks.AddOrUpdate(projectTask);
		}
    }
}
