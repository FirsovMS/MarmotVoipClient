using MarmotVoipClient.Model.Data;

namespace MarmotVoipClient.UI.Data
{
	public interface IContactDataService
	{
		Contact GetById(int contactId);

		void Save(Contact contact);
	}
}