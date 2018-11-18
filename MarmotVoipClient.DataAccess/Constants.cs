namespace MarmotVoipClient.DataAccess
{
	public static class Constants
	{
#if DEBUG
		private static readonly string PathToRoot = @"C:\Users\Michael\source\repos\MarmotVoipClient";
		public static readonly string CONNECTION_STRING = $"Data Source={PathToRoot}\\test_db.db;Pooling=true;FailIfMissing=false";
#else
		public static readonly string CONNECTION_STRING = @"Data Source=./data.db;Version=3;";
#endif

		public static readonly string DA_TRANSACTION_BEGIN = "BEGIN TRANSACTION";

		public static readonly string DA_TRANSACTION_COMMIT = "COMMIT;";

		public static readonly string DA_CALL_HISTORY_GET_ALL =
			"SELECT id, contact_id, type FROM contacts;";

		public static readonly string DA_CALL_HISTORY_GET_BY_ID_FMT =
			"SELECT id, contact_id, type FROM contacts WHERE id = {0};";

		public static readonly string DA_CALL_HISTORY_INSERT_NEW_VALUES_FMT =
			"INSERT INTO call_history(contact_id, type) VALUES ({0}, {1})";

		public static readonly string DA_CALL_HISTORY_DELETE_VALUE_BY_ID_FMT =
			"DELETE FROM call_history WHERE id = {0};";

		public static readonly string DA_CONTACTS_GET_BY_ID_FMT =
			"SELECT contact_id, first_name, last_name, sip FROM contacts WHERE contact_id = {0};";

		public static readonly string DA_CONTACTS_GET_BY_SIP_FMT =
			"SELECT contact_id, first_name, last_name, sip FROM contacts WHERE sip = '{0}';";

		public static readonly string DA_CONTACTS_GET_ALL =
			"SELECT contact_id, first_name, last_name, sip FROM contacts;";

		public static readonly string DA_CONTACTS_INSERT_NEW_VALUES_FMT =
			"INSERT INTO contacts(contact_id, first_name, last_name, sip) VALUES ({0} ,'{1}', '{2}', '{3}');";

		public static readonly string DA_CONTACTS_DELETE_VALUE_BY_ID_FMT =
			"DELETE FROM contacts WHERE contact_id = {0};";

		public static readonly string DA_CONTACTS_UPDATE_VALUE_BY_ID_FMT =
			"UPDATE contacts SET first_name = '{1}', last_name = '{2}', sip = '{3}' WHERE contact_id = {0};";
	}
}
