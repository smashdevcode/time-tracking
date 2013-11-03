using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.Data.Models;
using TimeTracking.MvcApplication.Infrastructure;
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
			return View(new TimeEntryViewModel());
        }

		[HttpPost]
		public ActionResult Add(TimeEntryViewModel timeEntryViewModel)
		{
			if (ModelState.IsValid)
			{
				var timeEntry = timeEntryViewModel.GetTimeEntry();
				_repository.SaveTimeEntry(timeEntry);

				// redirect to the "time in" date
				var timeInDate = timeEntryViewModel.TimeInDate ?? DateTime.Now;
				return RedirectToRoute("Date",
					new { date = timeInDate.ToString("yyyy-MM-dd") });
			}
			else
			{
				return View(timeEntryViewModel);
			}
		}

		public ActionResult Edit(int id)
		{
			var timeEntry = _repository.GetTimeEntry(id);
			// if we didn't get a time entry back, redirect the user back to the home page
			if (timeEntry == null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(new TimeEntryViewModel(timeEntry));
		}

		[HttpPost]
		public ActionResult Edit(TimeEntryViewModel timeEntryViewModel)
		{
			if (ModelState.IsValid)
			{
				var timeEntry = timeEntryViewModel.GetTimeEntry();
				_repository.SaveTimeEntry(timeEntry);

				// redirect to the "time in" date
				return RedirectToRoute("Date", 
					new { date = timeEntryViewModel.TimeInDate.Value.ToString("yyyy-MM-dd") });
			}
			else
			{
				return View(timeEntryViewModel);
			}
		}

		[HttpPost]
		public ActionResult Delete(int timeEntryId)
		{
			_repository.DeleteTimeEntry(timeEntryId);

			return RedirectToAction("Index", "Home");
		}

		public ActionResult GetProjectTasks(int id)
		{
			var projectTasks = _repository.GetProjectTasks(id);
			return Json(projectTasks, JsonRequestBehavior.AllowGet);
		}
	}
}
