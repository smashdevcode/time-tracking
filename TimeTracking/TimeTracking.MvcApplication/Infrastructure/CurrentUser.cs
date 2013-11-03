using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeTracking.Data;
using TimeTracking.Data.Models;

namespace TimeTracking.MvcApplication.Infrastructure
{
	public class CurrentUser : ICurrentUser
	{
		private IRepository _repository;
		private User _currentUser;

		public CurrentUser(IRepository repository)
		{
			_repository = repository;
			// TODO replace with reference to the logged in user
			_currentUser = _repository.GetUser(1);
		}

		public int UserId
		{
			get
			{
				return _currentUser.UserId;
			}
		}

		public User User
		{
			get
			{
				return _currentUser;
			}
		}
	}
}