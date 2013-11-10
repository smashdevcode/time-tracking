using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.MvcApplication.ViewModels;

namespace TimeTracking.MvcApplication.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index(DateTime? date = null)
        {
            return View(new HomeIndexViewModel(date));
        }
    }
}
