using static MarmotVoipClient.Model.Enums;

namespace MarmotVoipClient.Model.Data
{
	public class HistoryItem
	{
		public int Id { get; set; }

		public ActionType ItemType { get; set; }

		public int CallId { get; set; }

		public int MessageId { get; set; }
	}
}
