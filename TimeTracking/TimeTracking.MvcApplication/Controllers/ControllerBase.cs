using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;

namespace TimeTracking.MvcApplication.Controllers
{
	public abstract class ControllerBase : Controller
	{
		protected IRepository _repository;

		public ControllerBase()
		{
			_repository = DependencyResolver.Current.GetService<IRepository>();
		}
	}
}