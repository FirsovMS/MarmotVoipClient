using MarmotVoipClient.DataAccess;
using MarmotVoipClient.Model;
using MarmotVoipClient.Model.Data;
using System.Collections.Generic;
using System.Linq;

namespace MarmotVoipClient.UI.Data.Lookups
{
	public class ContactLookupDataService : IContactLookupDataService
	{
		private readonly ContactsDAO ContactsDAO;

		public ContactLookupDataService(ContactsDAO contactsDAO)
		{
			ContactsDAO = contactsDAO;
		}

		public IEnumerable<ContactLookupItem> GetLookups()
		{
			IEnumerable<Contact> contacts = ContactsDAO.GetAll();
			return contacts.Select(contact => new ContactLookupItem()
			{
				Id = contact.Id,
				DisplayMember = $"{contact.FirstName} {contact.LastName}"
			});
		}
	}
}
