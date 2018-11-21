using MarmotVoipClient.Model.Data;
using System;

namespace MarmotVoipClient.Model
{
	public static class Extensions
	{
		public static TimeSpan GetDuration(this CallItem callItem)
		{
			return callItem.TimeEnd - callItem.TimeStart;
		}
	}
}
