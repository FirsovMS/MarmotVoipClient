using System.Collections.Generic;
using MarmotVoipClient.Model;

namespace MarmotVoipClient.UI.Data
{
	public interface IContactLookupDataService
	{
		IEnumerable<ContactLookupItem> GetLookups();
	}
}