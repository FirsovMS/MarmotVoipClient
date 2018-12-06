using System.Collections.Generic;
using MarmotVoipClient.Model;

namespace MarmotVoipClient.UI.Data.Lookups
{
	public interface IContactLookupDataService
	{
		IEnumerable<ContactLookupItem> GetLookups();
	}
}