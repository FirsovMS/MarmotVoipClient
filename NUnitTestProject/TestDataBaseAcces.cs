using DAL;
using NUnit.Framework;
using System;
using System.Data;
using System.Linq;

namespace NUnitTestProject
{
	[TestFixture]
	public class TestDataBaseAcces
	{
		private static readonly string PathToDbFile = @"C:\Users\Michael\source\repos\MarmotVoipClient";
		private static readonly string ConnString = $"Data Source={PathToDbFile}\\data.db;Pooling=true;FailIfMissing=false";

		[Test]
		public void TestDatabaseConnection()
		{
			DataAccessLayer dal = new DataAccessLayer(ConnString);

			Assert.AreEqual(dal.ConnectionStatus, ConnectionState.Open);
		}

		[Test]
		public void TestExecuteSelectVersion()
		{
			DataAccessLayer dal = new DataAccessLayer(ConnString);

			var version = dal.ExecuteQuery("select sqlite_version();", row => (string)row[0]).FirstOrDefault();

			Assert.IsFalse(string.IsNullOrWhiteSpace(version));
		}

	}
}
