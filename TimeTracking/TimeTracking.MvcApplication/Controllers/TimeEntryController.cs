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
    public class TimeEntryController : ControllerBase
    {
		public ActionResult Add()
        {
			return View(new TimeEntryViewModel());
        }

		[HttpPost]
		public ActionResult Add(TimeEntryViewModel timeEntryViewModel)
		{
			if (ModelState.IsValid)
			{
				return timeEntryViewModel.Save();
			}
			else
			{
				return View(timeEntryViewModel);
			}	
		}

		public ActionResult Edit(int id)
		{
			var viewModel = new TimeEntryViewModel(id);

			// if we didn't get a model back, redirect the user back to the home page
			if (!viewModel.HasModel)
				return RedirectToAction("Index", "Home");

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(TimeEntryViewModel timeEntryViewModel)
		{
			if (ModelState.IsValid)
			{
				return timeEntryViewModel.Save();
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
