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
			// TODO remove???
			//var projectTasks = _repository.GetProjectTasks(projects[0].ProjectId);
			var timeEntryAddViewModel = new TimeEntryAddViewModel()
			{
				Projects = projects,
				// TODO remove???
				//ProjectTasks = projectTasks
			};
			return View(timeEntryAddViewModel);
        }

		[HttpPost]
		public ActionResult Add(TimeEntryAddViewModel timeEntryAddViewModel)
		{
			// TODO replace with reference to the logged in user
			var user = _repository.GetUser(1);

			if (ModelState.IsValid)
			{
				var timeEntry = timeEntryAddViewModel.GetTimeEntry(user);
				_repository.SaveTimeEntry(timeEntry);

				return RedirectToAction("Index", "Home");
			}
			else
			{
				var projects = _repository.GetProjects(user.UserId);
				timeEntryAddViewModel.Projects = projects;
				// TODO remove???
				//var projectTasks = _repository.GetProjectTasks(projects[0].ProjectId);
				//timeEntryAddViewModel.ProjectTasks = projectTasks;
		
				return View(timeEntryAddViewModel);
			}
		}

		public ActionResult GetProjectTasks(int id)
		{
			var projectTasks = _repository.GetProjectTasks(id);
			return Json(projectTasks, JsonRequestBehavior.AllowGet);
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

			var projects = _repository.GetProjects(user.UserId);
			// TODO remove???
			var projectTasks = _repository.GetProjectTasks(timeEntry.ProjectTask.ProjectId);
			var timeEntryAddViewModel = new TimeEntryAddViewModel()
			{
				Projects = projects,
				// TODO remove???
				ProjectTasks = projectTasks
			};
			timeEntryAddViewModel.SetTimeEntry(timeEntry, user);
			return View(timeEntryAddViewModel);
		}

		[HttpPost]
		public ActionResult Edit(TimeEntryAddViewModel timeEntryAddViewModel)
		{
			// TODO replace with reference to the logged in user
			var user = _repository.GetUser(1);

			if (ModelState.IsValid)
			{
				var timeEntry = timeEntryAddViewModel.GetTimeEntry(user);
				_repository.SaveTimeEntry(timeEntry);

				return RedirectToAction("Index", "Home");
			}
			else
			{
				var projects = _repository.GetProjects(user.UserId);
				timeEntryAddViewModel.Projects = projects;
				// TODO remove???
				var projectTasks = _repository.GetProjectTasks(projects[0].ProjectId);
				timeEntryAddViewModel.ProjectTasks = projectTasks;

				return View(timeEntryAddViewModel);
			}
		}

		[HttpPost]
		public ActionResult Delete(int timeEntryId)
		{
			_repository.DeleteTimeEntry(timeEntryId);

			return RedirectToAction("Index", "Home");
		}
    }
}
