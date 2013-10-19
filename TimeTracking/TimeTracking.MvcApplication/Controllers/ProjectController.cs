using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.Data.Models;

namespace TimeTracking.MvcApplication.Controllers
{
    public class ProjectController : Controller
    {
		private IRepository _repository;

		public ProjectController(IRepository repository)
		{
			_repository = repository;
		}

		public ActionResult Index()
        {
            return View();
        }

		public ActionResult Add()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Add(Project project)
		{
			return View();
		}

		public ActionResult Edit(int projectId)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Edit(Project project)
		{
			return View();
		}
	}
}
