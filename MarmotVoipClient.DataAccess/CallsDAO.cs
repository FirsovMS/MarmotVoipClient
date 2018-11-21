using DAL;
using MarmotVoipClient.Model;
using System;
using LoggingAPI;
using System.Collections.Generic;
using System.Linq;
using MarmotVoipClient.Model.Data;
using System.Data;

namespace MarmotVoipClient.DataAccess
{
	public class CallsDAO : BaseDAO, IBaseActions<CallItem>
	{
		public CallsDAO(DataAccessLayer dataAccessLayer) : base(dataAccessLayer)
		{
		}

		public bool TryAdd(CallItem value)
		{
			var contactID = value.Id.ToString();
			var callDirection = ((int)value.CallType).ToString();

			var query = queryBuilder.Add(Constants.DA_CALL_INSERT_RECORD_FMT)
				.AddParams(contactID, callDirection)
				.Build();

			return DAL.TryExecuteUpdate(query);
		}

		public IEnumerable<CallItem> GetAll()
		{
			IEnumerable<CallItem> result = null;

			try
			{
				result = DAL.ExecuteQuery(Constants.DA_CALLS_GET_ALL, row => CallHandler(row));
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get all CallItems!", ex, Level.Error, Constants.DA_CALLS_GET_ALL);
			}
			return result;
		}

		public IEnumerable<CallItem> GetAll(Contact owner)
		{
			IEnumerable<CallItem> result = null;

			var ownerID = owner.Id.ToString();
			var query = queryBuilder.Add(Constants.DA_CALLS_GET_BY_FROM_OR_TO_FMT)
				.AddParams(ownerID, ownerID)
				.Build();

			try
			{
				result = DAL.ExecuteQuery(query, row => CallHandler(row));
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get all CallHistoryItems!", ex, Level.Error, query);
			}
			return result;
		}

		public IEnumerable<CallItem> GetAll(DateTime start, DateTime end)
		{
			IEnumerable<CallItem> result = null;

			var query = queryBuilder.Add(Constants.DA_CALLS_GET_BY_TIME_RANGE_FMT)
				.AddParams(start.ToString(), end.ToString())
				.Build();
			try
			{
				result = DAL.ExecuteQuery(query, row => CallHandler(row));
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get all CallHistoryItems!", ex, Level.Error, query);
			}
			return result;
		}

		public bool TryGet(int id, out CallItem value)
		{
			bool opResult = false;
			var query = queryBuilder.Add(Constants.DA_CALLS_GET_BY_ID_FMT)
				.AddParams(id.ToString())
				.Build();

			value = null;
			try
			{
				var result = DAL.ExecuteQuery(query, row => CallHandler(row))?.FirstOrDefault();

				opResult = result != null;
				if (opResult)
				{
					value = result;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't handle or get CallHistoryItem by ID!", ex, Level.Error, query);
			}
			return opResult;
		}

		public bool TryRemove(CallItem value)
		{
			var query = queryBuilder.Add(Constants.DA_CALL_REMOVE_BY_ID_FMT)
				.AddParams(value.Id.ToString())
				.Build();

			return DAL.TryExecuteUpdate(query);
		}

		public bool TryUpdate(CallItem value)
		{
			var query = queryBuilder.Add(Constants.DA_CALL_UPDATE_RECORD_BY_ID_FMT)
				.AddParams(value.Id.ToString(), value.FromId.ToString(), value.ToId.ToString(), ((int)value.CallType).ToString(),
					value.TimeStart.ToString(), value.TimeEnd.ToString())
				.Build();

			return DAL.TryExecuteUpdate(query);
		}

		private static CallItem CallHandler(DataRow row)
		{
			return new CallItem()
			{
				Id = Convert.ToInt32(row["call_id"]),
				FromId = Convert.ToInt32(row["from_id"]),
				ToId = Convert.ToInt32(row["to_id"]),
				CallType = (Enums.CallType)Convert.ToInt32(row["call_type"]),
				TimeStart = DateTime.Parse(row["time_start"].ToString()),
				TimeEnd = DateTime.Parse(row["time_end"].ToString())
			};
		}
	}
}
