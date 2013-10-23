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

			AddProject(context, 1, 1, "CIS: Liability & Workers' Comp Claims Management System - Elaboration Phase");
			AddProject(context, 2, 1, "LP: Barcode Scanning App");
			AddProject(context, 3, 1, "McMenamins: MCM-12 Events-Phase 1");
			AddProject(context, 4, 1, "R2C: Tracker-2 Development");
			AddProject(context, 5, 1, "R2C: Tracker-2 Maintenance");
			AddProject(context, 6, 1, "SSII: Managed Services - Web Apps");
			AddProject(context, 7, 1, "CSG: Internal projects - AppDev");

			AddProjectTask(context, 1, 1, true, true);
			AddProjectTask(context, 2, 2, true, true);
			AddProjectTask(context, 3, 3, true, true);
			AddProjectTask(context, 4, 4, true, true);
			AddProjectTask(context, 5, 5, true, true);
			AddProjectTask(context, 6, 6, true, true);
			AddProjectTask(context, 7, 7, false, true, "Pre Sales");
			AddProjectTask(context, 8, 7, false, true, "Training/Conference");
			AddProjectTask(context, 9, 7, false, true, "Travel Time");
			AddProjectTask(context, 10, 7, false, true, "Research");
			AddProjectTask(context, 11, 7, false, true, "Practice Development");
			AddProjectTask(context, 12, 7, false, true, "Practice Administration");
			AddProjectTask(context, 13, 7, false, true, "Team Meeting");
			AddProjectTask(context, 14, 7, false, true, "1:1 Team Member Meeting");
        }

		private void AddProject(Context context, int projectId, int userId, string name)
		{
			var project = new Project()
			{
				ProjectId = projectId,
				UserId = userId,
				Name = name
			};
			context.Projects.AddOrUpdate(project);
		}
		private void AddProjectTask(Context context, int projectTaskId, int projectId, bool billable, 
			bool requireComment, string name = "Default")
		{
			var projectTask = new ProjectTask()
			{
				ProjectTaskId = projectTaskId,
				ProjectId = projectId,
				Billable = billable,
				RequireComment = requireComment,
				Name = name
			};
			context.ProjectTasks.AddOrUpdate(projectTask);
		}
    }
}
