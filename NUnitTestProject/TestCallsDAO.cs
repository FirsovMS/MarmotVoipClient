using DAL;
using MarmotVoipClient.DataAccess;
using MarmotVoipClient.Model.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarmotVoipClient.Model.Enums;

namespace NUnitTestProject
{
	[TestFixture]
	class TestCallsDAO
	{
		private static readonly DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);

		[Test]
		public void TestOpGetAllCalls()
		{
			var dao = new CallsDAO(dal);

			Assert.IsTrue(dao.GetAll().Any());
		}

		[Test]
		public void TestOpGetAllCallsByContact()
		{
			var dao = new CallsDAO(dal);

			var calls = dao.GetAll(Constants.mockContact);

			Assert.IsTrue(calls.Any());
		}

		[Test]
		public void TestOpGetCallsByTimeRange()
		{
			var dao = new CallsDAO(dal);

			var startTime = DateTime.Parse("2018-11-19 17:00:00");
			var endTime = DateTime.Parse("2018-11-19 18:00:00");

			var calls = dao.GetAll(startTime, endTime);
			Assert.IsTrue(calls.Any());
		}

		[Test]
		public void TestOpGetCallByType()
		{
			var dao = new CallsDAO(dal);
			var calls = dao.GetAll(CallType.Outcoming);

			Assert.NotNull(calls.First());
		}

		[Test]
		public void TestOpGetCallById()
		{
			var dao = new CallsDAO(dal);
			var mock = dao.GetAll().First();

			CallItem result = null;
			dao.TryGet(mock.Id, out result);

			Assert.NotNull(result);
			Assert.AreEqual(mock.Id, result.Id);
			Assert.AreEqual(mock.SourceId, result.SourceId);
			Assert.AreEqual(mock.DestinationId, result.DestinationId);
			Assert.AreEqual(mock.TimeStart, result.TimeStart);
			Assert.AreEqual(mock.TimeEnd, result.TimeEnd);
		}
	}
}
