using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracking.Data.Models;

namespace TimeTracking.MvcApplication.Infrastructure
{
	public interface ICurrentUser
	{
		int UserId { get; }
		User User { get; }
	}
}