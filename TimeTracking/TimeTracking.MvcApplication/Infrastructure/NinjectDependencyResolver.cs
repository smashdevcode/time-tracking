using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using TimeTracking.Data;
using System.Web.Mvc;

namespace TimeTracking.MvcApplication.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel _kernel;

		public NinjectDependencyResolver()
		{
			_kernel = new StandardKernel();
			AddBindings();
		}

		private void AddBindings()
		{
			_kernel.Bind<IRepository>().To<Repository>();
		}

		public object GetService(Type serviceType)
		{
			return _kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _kernel.GetAll(serviceType);
		}

		public void Dispose()
		{
			_kernel.Dispose();
		}
	}
}