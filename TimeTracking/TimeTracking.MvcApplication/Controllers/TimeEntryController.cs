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
