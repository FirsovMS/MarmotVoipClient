using DAL;
using MarmotVoipClient.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public void TestOpGetCallByTimeRange()
		{
			var dao = new CallsDAO(dal);

			Assert.Fail("Not implemented!");
		}

		[Test]
		public void TestOpGetCallByCaller()
		{
			var dao = new CallsDAO(dal);

			Assert.Fail("Not implemented!");
		}

		[Test]
		public void TestOpGetCallByType()
		{
			var dao = new CallsDAO(dal);

			Assert.Fail("Not implemented!");
		}

		[Test]
		public void TestOpGetAllContacts()
		{
			var dao = new CallsDAO(dal);

			Assert.Fail("Not implemented!");
		}
	}
}
