using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.Data.Models;

namespace TimeTracking.MvcApplication.Controllers
{
    public class TimeEntryController : Controller
    {
		private IRepository _repository;

		public TimeEntryController(IRepository repository)
		{
			_repository = repository;
		}

		public ActionResult Add()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Add(TimeEntry timeEntry)
		{
			return View();
		}

		public ActionResult Edit(int timeEntryId)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Edit(TimeEntry timeEntry)
		{
			return View();
		}
    }
}
