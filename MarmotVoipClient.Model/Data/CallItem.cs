using System;
using static MarmotVoipClient.Model.Enums;

namespace MarmotVoipClient.Model.Data
{
	public class CallItem
	{
		public int Id { get; set; }

		public int FromId { get; set; }

		public int ToId { get; set; }

		public CallType CallType { get; set; }

		public DateTime TimeStart { get; set; }

		public DateTime TimeEnd { get; set; }
	}
}
