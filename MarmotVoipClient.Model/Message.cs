using System;

namespace MarmotVoipClient.Model
{
	public class Message
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public DateTime Data { get; set; }

		public bool IsDelivered { get; set; }
	}
}
