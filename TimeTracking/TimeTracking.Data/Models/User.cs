using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Data.Models
{
	public class User
	{
		public int UserId { get; set; }
		[Required]
		[MaxLength(50)]
		public string Username { get; set; }
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required]
		[MaxLength(255)]
		public string Email { get; set; }
		[Required]
		[MaxLength(100)]
		public string TimeZoneId { get; set; }
	}
}
