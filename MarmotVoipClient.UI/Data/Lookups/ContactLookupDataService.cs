using MarmotVoipClient.DataAccess;
using MarmotVoipClient.Model;
using MarmotVoipClient.Model.Data;
using MarmotVoipClient.UI.Startup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarmotVoipClient.UI.Data.Lookups
{
    public class ContactLookupDataService : IContactLookupDataService
    {
        public IEnumerable<ContactLookupItem> GetLookups()
        {
            if (Configuration.IsDebugMode)
            {
                return MockLookups();
            }

            throw new NotImplementedException();
        }

        private IEnumerable<ContactLookupItem> MockLookups()
        {
            return new List<ContactLookupItem>()
            {
                new ContactLookupItem
                {
                    Id = 0,
                    DisplayMember = "Test0"
                },
                new ContactLookupItem
                {
                    Id = 1,
                    DisplayMember = "Test1"
                },
            };
        }
    }
}
