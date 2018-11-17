using LoggingAPI;
using MarmotVoipClient.DataAccess;
using MarmotVoipClient.Model.Data;

namespace MarmotVoipClient.UI.Data
{
	public class ContactDataService : IContactDataService
	{
		private readonly ContactsDAO ContactsDAO;

		public ContactDataService(ContactsDAO contactsDAO)
		{
			ContactsDAO = contactsDAO;
		}

		public Contact GetById(int contactId)
		{
			Contact result = null;
			if (!ContactsDAO.TryGet(contactId, out result))
			{
				Logger.Error($"Can't get contact by id: {contactId}");
			}
			return result;
		}

		public void Save(Contact contact)
		{
			ContactsDAO.Update(contact);
		}
	}
}
