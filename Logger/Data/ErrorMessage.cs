using System;

namespace LoggingAPI.Data
{
	[Serializable]
	public class ErrorMessage
	{
		public DateTime Date { get; set; }

		public Level LogLevel { get; set; }

		public string Description { get; set; }
	}
}
