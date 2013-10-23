using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.Data.Models;
using TimeTracking.MvcApplication.ViewModels;

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
			// TODO replace with reference to the logged in user
			var user = _repository.GetUser(1);

			var projects = _repository.GetProjects(user.UserId);
			var timeEntryAddViewModel = new TimeEntryAddViewModel() { Projects = projects };
			return View(timeEntryAddViewModel);
        }

		[HttpPost]
		public ActionResult Add(TimeEntryAddViewModel timeEntryAddViewModel)
		{
			// TODO check if the model is in a valid state
			// TODO get the time entry from the database
			// TODO save the time entry record
			// TODO redirect to the home page

			if (ModelState.IsValid)
			{
				var timeEntry = timeEntryAddViewModel.GetTimeEntry();
				//_repository.SaveTimeEntry(timeEntry);

				return RedirectToAction("Index", "Home");
			}
			else
			{
				// TODO set the collection property values again???
				return View(timeEntryAddViewModel);
			}
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
