using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.MvcApplication.ViewModels;

namespace TimeTracking.MvcApplication.Controllers
{
    public class HomeController : Controller
    {
		private IRepository _repository;

		public HomeController(IRepository repository)
		{
			_repository = repository;
		}

        public ActionResult Index(DateTime? date = null)
        {
			if (date == null)
				date = DateTime.Today;

			// TODO replace with reference to the logged in user
			var user = _repository.GetUser(1);

			var timeEntries = _repository.GetTimeEntries(date.Value, user);

            return View(new HomeIndexViewModel(date.Value, timeEntries));
        }
    }
}
