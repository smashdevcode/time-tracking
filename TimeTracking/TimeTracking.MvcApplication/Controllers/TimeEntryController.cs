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

			var timeEntryViewModel = new TimeEntryViewModel();

			var projects = _repository.GetProjects(user.UserId);
			var projectTasks = _repository.GetProjectTasks(projects[0].ProjectId);
			timeEntryViewModel.Projects = projects;
			timeEntryViewModel.ProjectTasks = projectTasks;

			return View(timeEntryViewModel);
        }

		[HttpPost]
		public ActionResult Add(TimeEntryViewModel timeEntryViewModel)
		{
			// TODO replace with reference to the logged in user
			var user = _repository.GetUser(1);

			if (ModelState.IsValid)
			{
				var timeEntry = timeEntryViewModel.GetTimeEntry(user);
				_repository.SaveTimeEntry(timeEntry);

				// redirect to the "time in" date
				var timeInDate = timeEntryViewModel.TimeInDate ?? DateTime.Now;
				return RedirectToRoute("Date",
					new { date = timeInDate.ToString("yyyy-MM-dd") });
			}
			else
			{
				var projects = _repository.GetProjects(user.UserId);
				var projectTasks = _repository.GetProjectTasks(projects[0].ProjectId);
				timeEntryViewModel.Projects = projects;
				timeEntryViewModel.ProjectTasks = projectTasks;
		
				return View(timeEntryViewModel);
			}
		}

		public ActionResult Edit(int id)
		{
			// TODO replace with reference to the logged in user
			var user = _repository.GetUser(1);

			var timeEntry = _repository.GetTimeEntry(id);
			// if we didn't get a time entry back, redirect the user back to the home page
			if (timeEntry == null)
			{
				return RedirectToAction("Index", "Home");
			}

			var timeEntryViewModel = new TimeEntryViewModel();

			var projects = _repository.GetProjects(user.UserId);
			var projectTasks = _repository.GetProjectTasks(timeEntry.ProjectTask.ProjectId);
			timeEntryViewModel.Projects = projects;
			timeEntryViewModel.ProjectTasks = projectTasks;
			timeEntryViewModel.SetTimeEntry(timeEntry, user);

			return View(timeEntryViewModel);
		}

		[HttpPost]
		public ActionResult Edit(TimeEntryViewModel timeEntryViewModel)
		{
			// TODO replace with reference to the logged in user
			var user = _repository.GetUser(1);

			if (ModelState.IsValid)
			{
				var timeEntry = timeEntryViewModel.GetTimeEntry(user);
				_repository.SaveTimeEntry(timeEntry);

				// redirect to the "time in" date
				return RedirectToRoute("Date", 
					new { date = timeEntryViewModel.TimeInDate.Value.ToString("yyyy-MM-dd") });
			}
			else
			{
				var projects = _repository.GetProjects(user.UserId);
				var projectTasks = _repository.GetProjectTasks(projects[0].ProjectId);
				timeEntryViewModel.Projects = projects;
				timeEntryViewModel.ProjectTasks = projectTasks;

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
