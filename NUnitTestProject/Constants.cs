using MarmotVoipClient.Model.Data;

namespace NUnitTestProject
{
	internal class Constants
	{
		private static readonly string PathToRoot = @"C:\Users\Michael\source\repos\MarmotVoipClient";

		public static readonly string ConnString = $"Data Source={PathToRoot}\\test_db.db;Pooling=true;FailIfMissing=false";

		public static readonly Contact mockContact = new Contact(1, "Ivan", "Ivanovich", "sip@example");
	}
}
