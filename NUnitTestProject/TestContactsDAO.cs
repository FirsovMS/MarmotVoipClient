using DAL;
using MarmotVoipClient.DataAccess;
using MarmotVoipClient.Model.Data;
using NUnit.Framework;
using System;

namespace NUnitTestProject
{
	[TestFixture]
	public class TestContactsDAO
	{
		private Contact mockContact = new Contact(1, "Ivan", "Ivanovich", "sip@example");

		[Test]
		public void TestOpGetAllContacts()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			var contacts = contactsDAO.GetAll();

			Assert.NotNull(contacts);
		}

		[Test]
		public void TestOpGetMockContact()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			Contact result = null;
			if (contactsDAO.TryGet(1, out result))
			{
				Assert.AreEqual(mockContact.FirstName, result.FirstName);
				Assert.AreEqual(mockContact.LastName, result.LastName);
				Assert.AreEqual(mockContact.Id, result.Id);
				Assert.AreEqual(mockContact.Sip, result.Sip);
			}
			else
			{
				throw new NullReferenceException("Didn't load contact!");
			}
		}

		[Test]
		public void TestOpAddAndVerifyMockContact()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			var mock = new Contact("MockFirstName", "MockLastName", "mock@example");
			contactsDAO.TryAdd(mock);

			Contact result = null;
			if (contactsDAO.TryGet(mock.Sip, out result))
			{
				Assert.AreEqual(mock.FirstName, result.FirstName);
				Assert.AreEqual(mock.LastName, result.LastName);
				Assert.AreEqual(mock.Sip, result.Sip);
			}
			else
			{
				Assert.Fail("Didn't load contact!");
			}
		}

		[Test]
		public void TessOpUpdateMockContact()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			Contact mock = (Contact)mockContact.Clone();
			mock.FirstName = "MockingMock!";
			contactsDAO.TryUpdate(mock);

			// check updated value
			Contact result = null;
			if (!contactsDAO.TryGet(mock.Id, out result))
			{
				Assert.Fail("Can't get updated value!");
			}
			Assert.AreEqual(mock.FirstName, result.FirstName);

			ResetMockValueToDefaults(contactsDAO);
		}

		[Test]
		public void TestOpRemoveContact()
		{
			DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			// remove mock
			if (!contactsDAO.TryRemove(mockContact))
			{
				Assert.Fail("Can't remove mock contact from database!");
			}

			Contact result = null;
			if (contactsDAO.TryGet(mockContact.Id, out result))
			{
				Assert.Fail("Mock was not removed!");
			}
		}

		private void ResetMockValueToDefaults(ContactsDAO contactsDAO)
		{
			Contact result = null;
			if (!contactsDAO.TryGet(mockContact.Id, out result))
			{
				if (!contactsDAO.TryAdd(mockContact))
				{
					Assert.Fail("Can't add default mock! See log result!");
				}
			}
			else
			{
				if (!contactsDAO.TryUpdate(mockContact))
				{
					Assert.Fail("Can't update default mock! See log result!");
				}
			}

			if (!contactsDAO.TryGet(mockContact.Id, out result))
			{
				Assert.Fail("Can't get updated value!");
			}
			Assert.AreEqual(mockContact.FirstName, result.FirstName);
		}
	}
}
