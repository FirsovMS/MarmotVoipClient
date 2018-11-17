using LoggingAPI;
using MarmotVoipClient.DataAccess;
using MarmotVoipClient.Model;

namespace MarmotVoipClient.UI.Data
{
	public class ContactDataService
    {
		private ContactsDAO ContactsDAO;

		public ContactDataService(ContactsDAO contactsDAO)
		{
			ContactsDAO = contactsDAO;
		}

		public Contact GetById(int contactId)
		{
			Contact result = null;
			if (!ContactsDAO.TryGet(contactId, out result))
			{
				Logger.Error
			}
		}

		public void Save(Contact contact)
		{

		}
	}
}
