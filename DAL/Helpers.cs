using System;

namespace DAL
{
	public static class Helpers
	{
		public static string ToSQLiteTimeFormat(this DateTime time)
		{
			return time.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}
