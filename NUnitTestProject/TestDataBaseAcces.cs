using DAL;
using NUnit.Framework;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTestProject
{
	[TestFixture]
	public class TestDataBaseAcces
	{
		[Test]
		public void TestDatabaseConnection()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);

			Assert.AreEqual(dal.ConnectionStatus, ConnectionState.Open);
		}

		[Test]
		public void TestExecuteSelectVersion()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);

			var version = dal.ExecuteQuery("select sqlite_version();", row => (string)row[0]).FirstOrDefault();

			Assert.IsFalse(string.IsNullOrWhiteSpace(version));
		}

		[Test]
		public async Task TestExecuteSelectVersionAsync()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);

			var version = (await dal.ExecuteQueryAsync("select sqlite_version();", row => (string)row[0])).FirstOrDefault();

			Assert.IsFalse(string.IsNullOrWhiteSpace(version));
		}
	}
}