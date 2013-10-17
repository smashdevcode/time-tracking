using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Models
{
	public class ProjectTask
	{
		public int ProjectTaskId { get; set; }
		public int ProjectId { get; set; }
		public string Name { get; set; }

		public Project Project { get; set; }
	}
}
