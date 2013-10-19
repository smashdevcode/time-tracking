using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;

namespace TimeTracking.MvcApplication.Controllers
{
    public class HomeController : Controller
    {
		private IRepository _repository;

		public HomeController(IRepository repository)
		{
			_repository = repository;
		}

        public ActionResult Index()
        {
            return View();
        }
    }
}
