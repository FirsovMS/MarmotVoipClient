using System;

namespace LoggingAPI.Data
{
	[Serializable]
	public class ErrorMessageWithSql : ErrorMessage
	{
		public string SqlQuery { get; set; }
	}
}
