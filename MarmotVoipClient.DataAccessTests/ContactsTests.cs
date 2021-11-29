using MarmotVoipClient.DataAccess;
using MarmotVoipClient.DataAccess.DTO;
using NUnit.Framework;
using FluentAssertions;

namespace MarmotVoipClient.DataAccessTests
{
    [TestFixture]
    public class ContactsTests
    {
        private ContactsContext db;

        [SetUp]
        public void SetUp()
        {
            db = new ContactsContext();
            db.Database.ExecuteSqlCommand("delete from Contacts");
            db.Database.ExecuteSqlCommand(@"update sqlite_sequence 
                                            set seq = 0
                                            where name = 'Contacts'");
            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            db?.Dispose();
        }

        [Test]
        public void AddNewContact_ShouldAddSuccessfully()
        {
            var expected = new ContactDTO
            {
                Name = "Test1",
                PhoneNumber = 123456789
            };

            var added = db.Contacts.Add(expected);
            db.SaveChanges();

            var actual = db.Contacts.Find(added.ContactId);

            actual.Should().BeEquivalentTo(expected, config =>
                config.Excluding(ctx => ctx.ContactId)
            );
        }

        [Test]
        public void EditingContactPhoneNumber_ShouldEditSuccessfully()
        {
            const int editedPhoneNumber = 775353535;

            var newContact = new ContactDTO
            {
                Name = "Test1",
                PhoneNumber = 123456789
            };

            var added = db.Contacts.Add(newContact);
            db.SaveChanges();

            added = db.Contacts.Find(added.ContactId);
            added.PhoneNumber = editedPhoneNumber;

            db.SaveChanges();

            var expected = new ContactDTO
            {
                ContactId = added.ContactId,
                Name = newContact.Name,
                PhoneNumber = editedPhoneNumber,
                Blocked = added.Blocked
            };

            var actual = db.Contacts.Find(added.ContactId);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void RemovingContact_ShouldRemoveSuccessfully()
        {
            var expected = new ContactDTO
            {
                Name = "Test1",
                PhoneNumber = 123456789
            };

            var added = db.Contacts.Add(expected);
            db.SaveChanges();

            db.Contacts.Remove(added);
            db.SaveChanges();

            var actual = db.Contacts.Find(added.ContactId);

            Assert.Null(actual);
        }
    }
}