using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Models
{
	public class Project
	{
		public Project()
		{
			ProjectTasks = new List<ProjectTask>();
		}

		public int ProjectId { get; set; }
		public string Name { get; set; }

		public List<ProjectTask> ProjectTasks { get; set; }
	}
}
