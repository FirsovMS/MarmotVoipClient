using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.DataAccess
{
    internal static class Constants
    {
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
            "SELECT id, first_name, last_name, sip_url, email FROM contacts WHERE id = {0};";

        public static readonly string DA_CONTACTS_GET_ALL =
            "SELECT id, first_name, last_name, sip_url, email FROM contacts;";

        public static readonly string DA_CONTACTS_INSERT_NEW_VALUES_FMT =
            "INSERT INTO contacts(first_name, last_name, sip_url, email) VALUES (`{0}`, `{1}`, `{2}`, `{3}`);";

        public static readonly string DA_CONTACTS_DELETE_VALUE_BY_ID_FMT =
            "DELETE FROM contacts WHERE id = {0};";

        public static readonly string DA_CONTACTS_UPDATE_VALUE_BY_ID_FMT =
            "UPDATE contacts SET first_name = `{1}`, last_name = `{2}`, sip_url = `{3}`, email = `{4}` WHERE id = {0};";
    }
}
