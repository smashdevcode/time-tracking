using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Data.Models;

namespace TimeTracking.MvcApplication.Tests.DataModelTests
{
	[TestClass]
	public class TimeEntryTests
	{
		[TestMethod]
		public void TimeEntry_TotalTimeNonBillable()
		{
			var timeEntry = new TimeEntry()
			{
				TimeInUtc = new DateTime(2013, 10, 1, 0, 0, 0),
				TimeOutUtc = new DateTime(2013, 10, 1, 1, 0, 0)
			};
			Assert.AreEqual(new TimeSpan(1, 0, 0), timeEntry.TotalTime);
			Assert.AreEqual(new TimeSpan(), timeEntry.TotalBillableTime);
		}

		[TestMethod]
		public void TimeEntry_TotalTimeBillable()
		{
			var timeEntry = new TimeEntry()
			{
				Billable = true,
				TimeInUtc = new DateTime(2013, 10, 1, 0, 0, 0),
				TimeOutUtc = new DateTime(2013, 10, 1, 1, 0, 0)
			};
			Assert.AreEqual(new TimeSpan(1, 0, 0), timeEntry.TotalTime);
			Assert.AreEqual(new TimeSpan(1, 0 , 0), timeEntry.TotalBillableTime);
		}

		[TestMethod]
		public void TimeEntry_TotalTimeInvalid()
		{
			var timeEntry = new TimeEntry()
			{
				TimeInUtc = new DateTime(2013, 10, 1, 1, 0, 0),
				TimeOutUtc = new DateTime(2013, 10, 1, 0, 0, 0)
			};
			Assert.AreEqual(new TimeSpan(), timeEntry.TotalTime);
			Assert.AreEqual(new TimeSpan(), timeEntry.TotalBillableTime);
		}
	}
}
