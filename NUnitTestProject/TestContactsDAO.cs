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
		private static readonly DataAccessLayer dal = new DataAccessLayer(Constants.ConnString);

		[Test]
		public void TestOpGetAllContacts()
		{
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			var contacts = contactsDAO.GetAll();

			Assert.NotNull(contacts);
		}

		[Test]
		public void TestOpGetMockContact()
		{
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			Contact result = null;
			if (contactsDAO.TryGet(1, out result))
			{
				Assert.AreEqual(Constants.mockContact.FirstName, result.FirstName);
				Assert.AreEqual(Constants.mockContact.LastName, result.LastName);
				Assert.AreEqual(Constants.mockContact.Id, result.Id);
				Assert.AreEqual(Constants.mockContact.Sip, result.Sip);
			}
			else
			{
				throw new NullReferenceException("Didn't load contact!");
			}
		}

		[Test]
		public void TestOpAddAndVerifyMockContact()
		{
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

			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			Contact mock = (Contact)Constants.mockContact.Clone();
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
			ContactsDAO contactsDAO = new ContactsDAO(dal);

			ResetMockValueToDefaults(contactsDAO);

			// remove mock
			if (!contactsDAO.TryRemove(Constants.mockContact))
			{
				Assert.Fail("Can't remove mock contact from database!");
			}

			Contact result = null;
			if (contactsDAO.TryGet(Constants.mockContact.Id, out result))
			{
				Assert.Fail("Mock was not removed!");
			}
		}

		private void ResetMockValueToDefaults(ContactsDAO contactsDAO)
		{
			Contact result = null;
			if (!contactsDAO.TryGet(Constants.mockContact.Id, out result))
			{
				if (!contactsDAO.TryAdd(Constants.mockContact))
				{
					Assert.Fail("Can't add default mock! See log result!");
				}
			}
			else
			{
				if (!contactsDAO.TryUpdate(Constants.mockContact))
				{
					Assert.Fail("Can't update default mock! See log result!");
				}
			}

			if (!contactsDAO.TryGet(Constants.mockContact.Id, out result))
			{
				Assert.Fail("Can't get updated value!");
			}
			Assert.AreEqual(Constants.mockContact.FirstName, result.FirstName);
		}
	}
}
