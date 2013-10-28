using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Models
{
	public class ProjectTask
	{
		public int ProjectTaskId { get; set; }
		public int ProjectId { get; set; }
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		public bool Billable { get; set; }
		public bool RequireComment { get; set; }

		[JsonIgnore]
		public Project Project { get; set; }
	}
}
