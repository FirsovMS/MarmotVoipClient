using Addititonals;
using LoggingAPI.Data;
using NLog;
using System;

namespace LoggingAPI
{
	public static class Logger
	{
		private static NLog.Logger logger;

		static Logger()
		{
			logger = LogManager.GetCurrentClassLogger();
		}

		public static void Info(string description)
		{
			logger.Info(description);
		}

		public static void Error(string description, Exception exception = null, Level logLevel = Level.Debug)
		{
			var message = new ErrorMessage()
			{
				Error = new ErrorDescription()
				{
					Description = description,
					Message = exception.Message,
					StackTrace = exception.StackTrace
				},
				Date = DateTime.Now,
				LogLevel = logLevel
			};
			LogError(message);
		}

		public static void Error(string description, string sqlQuery, Exception exception = null, Level logLevel = Level.Debug)
		{
			var message = new ErrorMessageWithSql()
			{
				Error = new ErrorDescription()
				{
					Description = description,
					Message = exception.Message,
					StackTrace = exception.StackTrace
				},
				SqlQuery = sqlQuery,
				Date = DateTime.Now,
				LogLevel = logLevel
			};
			LogError(message);
		}

		private static void LogError(ErrorMessage message)
		{
			switch (message.LogLevel)
			{
				case Level.Trace:
					logger.Trace(message.SerializeObject());
					break;
				case Level.Debug:
					logger.Debug(message.SerializeObject());
					break;
				case Level.Info:
					logger.Info(message.SerializeObject());
					break;
				case Level.Warn:
					logger.Warn(message.SerializeObject());
					break;
				case Level.Error:
					logger.Error(message.SerializeObject());
					break;
				case Level.Fatal:
					logger.Fatal(message.SerializeObject());
					break;
			}
		}
	}
}
