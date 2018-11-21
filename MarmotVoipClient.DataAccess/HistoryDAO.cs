using DAL;
using LoggingAPI;
using MarmotVoipClient.Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarmotVoipClient.Model.Enums;

namespace MarmotVoipClient.DataAccess
{
	class HistoryDAO : BaseDAO, IBaseActions<HistoryItem>
	{
		public HistoryDAO(DataAccessLayer dataAccessLayer) : base(dataAccessLayer)
		{
		}

		public IEnumerable<HistoryItem> GetAll()
		{
			IEnumerable<HistoryItem> result = null;
			try
			{
				DAL.ExecuteQuery(Constants.DA_HISTORY_GET_ALL, row => HandleHistoryItem(row));
			}
			catch (Exception ex)
			{
				Logger.Error("Can't execute get all HistoryItems!", ex, Level.Error);
			}
			return result;
		}

		public bool TryAdd(HistoryItem value)
		{
			throw new NotImplementedException();
		}

		public bool TryGet(int id, out HistoryItem value)
		{
			throw new NotImplementedException();
		}

		public bool TryRemove(HistoryItem value)
		{
			throw new NotImplementedException();
		}

		public bool TryUpdate(HistoryItem value)
		{
			throw new NotImplementedException();
		}

		private static HistoryItem HandleHistoryItem(DataRow dataRow)
		{
			return new HistoryItem()
			{
				Id = Convert.ToInt32(dataRow["id"]),
				ItemType = (ActionType)dataRow["item_type"],
				CallId = Convert.ToInt32(dataRow["call_id"]),
				MessageId = Convert.ToInt32(dataRow["msg_id"])
			};
		}
	}
}
