using NLog;
using System;

namespace LoggingAPI
{
	public static class Logger
	{
		private static Lazy<NLog.Logger> logger;

		static Logger()
		{
			logger = new Lazy<NLog.Logger>(() => LogManager.GetCurrentClassLogger(), true);
		}

		public static void Info(string description)
		{
			logger.Value.Info(description);
		}

		public static void Error(string description, Exception exception = null, Level logLevel = Level.Debug)
		{
			
		}

		public static void Error(string description, string query = null, Exception exception = null, Level logLevel = Level.Debug)
		{
			switch (logLevel)
			{
				case Level.Trace:
					logger.Value.Trace(exception, description);
					break;
				case Level.Debug:
					logger.Value.Debug(description);
					break;
				case Level.Info:
					logger.Value.Info(description);
					break;
				case Level.Warn:
					logger.Value.Warn(description);
					break;
				case Level.Error:
					logger.Value.Error(exception, description);
					break;
				case Level.Fatal:
					logger.Value.Fatal(exception, description);
					break;
			}
		}
	}
}
