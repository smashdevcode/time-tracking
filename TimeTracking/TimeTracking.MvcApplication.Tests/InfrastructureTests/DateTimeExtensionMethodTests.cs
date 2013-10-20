using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.MvcApplication.Infrastructure;

namespace TimeTracking.MvcApplication.Tests.InfrastructureTests
{
	[TestClass]
	public class DateTimeExtensionMethodTests
	{
		[TestMethod]
		public void DateTimeExtensionMethods_GetStartOfWeek()
		{
			Assert.AreEqual(new DateTime(2013, 10, 12), new DateTime(2013, 10, 12).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 12), new DateTime(2013, 10, 13).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 12), new DateTime(2013, 10, 14).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 12), new DateTime(2013, 10, 15).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 12), new DateTime(2013, 10, 16).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 12), new DateTime(2013, 10, 17).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 12), new DateTime(2013, 10, 18).GetStartOfWeek());

			Assert.AreEqual(new DateTime(2013, 10, 19), new DateTime(2013, 10, 19).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 19), new DateTime(2013, 10, 20).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 19), new DateTime(2013, 10, 21).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 19), new DateTime(2013, 10, 22).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 19), new DateTime(2013, 10, 23).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 19), new DateTime(2013, 10, 24).GetStartOfWeek());
			Assert.AreEqual(new DateTime(2013, 10, 19), new DateTime(2013, 10, 25).GetStartOfWeek());
		}
	}
}
