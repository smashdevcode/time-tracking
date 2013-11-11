using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracking.Data;
using TimeTracking.MvcApplication.Infrastructure;

namespace TimeTracking.MvcApplication.ViewModels
{
	public abstract class ViewModelBase
	{
		public enum ViewMode
		{
			Add,
			Edit
		}

		protected IRepository _repository;
		protected ICurrentUser _currentUser;

		public ViewModelBase()
		{
			_repository = DependencyResolver.Current.GetService<IRepository>();
			_currentUser = DependencyResolver.Current.GetService<ICurrentUser>();
		}

		public ViewMode Mode { get; set; }
	}
}