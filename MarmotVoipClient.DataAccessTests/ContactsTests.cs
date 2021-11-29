using MarmotVoipClient.DataAccess;
using MarmotVoipClient.DataAccess.DTO;
using NUnit.Framework;
using FluentAssertions;

namespace MarmotVoipClient.DataAccessTests
{
    [TestFixture]
    public class ContactsTests
    {
        private ApplicationContext _db;

        [SetUp]
        public void Setup()
        {
            _db = new ApplicationContext();
        }

        [TearDown]
        public void TearDown()
        {
            _db?.Dispose();
        }

        [Test]
        public void AddNewContact_ShouldAddSuccessfully()
        {
            var expected = new ContactDTO
            {
                Name = "Test1",
                PhoneNumber = 123456789
            };

            _db.Contacts.Add(expected);
            _db.SaveChanges();

            var actual = _db.Contacts.Find(expected.PhoneNumber);

            actual.Should().BeEquivalentTo(expected, config =>
                config.Excluding(ctx => ctx.Blocked)
            );
        }
    }
}