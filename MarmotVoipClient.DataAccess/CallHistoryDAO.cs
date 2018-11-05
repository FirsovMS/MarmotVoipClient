using DAL;
using MarmotVoipClient.Model;
using System;
using QueryBuilder;
using LoggingAPI;
using System.Collections.Generic;
using System.Linq;

namespace MarmotVoipClient.DataAccess
{
    public class CallHistoryDAO : IBaseActions<CallHistoryItem>
    {
        private readonly DataAccessLayer dal;
        private readonly ContactsDAO contactsDAO;
        private readonly QueryBuilderInstance queryBuilder;

        public CallHistoryDAO(DataAccessLayer dal, ContactsDAO contactsDAO)
        {
            this.dal = dal;
            this.contactsDAO = contactsDAO;

            queryBuilder = new QueryBuilderInstance();
        }

        public void Add(CallHistoryItem value)
        {
            var contactID = value.Contact.Id.ToString();
            var callDirection = ((int)value.CallDirection).ToString();

            var query = queryBuilder.Add(Constants.DA_CALL_HISTORY_INSERT_NEW_VALUES_FMT)
                .AddParams(contactID, callDirection)
                .Build();

            if (!dal.TryExecuteUpdate(query))
            {
                Logger.Error("Can't add record to call_history", query);
            }
        }

        public IEnumerable<CallHistoryItem> GetAll()
        {
            IEnumerable<CallHistoryItem> result = null;

            try
            {
                result = dal.ExecuteQuery(Constants.DA_CALL_HISTORY_GET_ALL, (row) => new CallHistoryItem(
                    (int)row["id"],
                    (int)row["contact_id"],
                    (Enums.CallDirection)row["type"]));
            }
            catch (Exception ex)
            {
                Logger.Error("Can't get all CallHistoryItems!", query: Constants.DA_CONTACTS_GET_ALL, exception: ex, warningLevel: Level.Error);
            }
            return result;
        }

        public bool TryGet(int id, out CallHistoryItem value)
        {
            bool opResult = false;
            value = CallHistoryItem.Default();

            var query = queryBuilder.Add(Constants.DA_CALL_HISTORY_GET_BY_ID_FMT)
                .AddParams(id.ToString())
                .Build();

            try
            {
                var result = dal.ExecuteQuery(query, (row) => new CallHistoryItem(
                    (int)row["id"],
                    (int)row["contact_id"],
                    (Enums.CallDirection)row["type"]))
                    .FirstOrDefault();

                opResult = result != null;
                if (opResult)
                {
                    value = result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Can't handle or get CallHistoryItem by ID!", query: query, exception: ex, warningLevel: Level.Error);
            }
            return opResult;
        }

        public bool TryRemove(CallHistoryItem value)
        {
            bool opResult = false;
            var query = queryBuilder.Add(Constants.DA_CALL_HISTORY_DELETE_VALUE_BY_ID_FMT)
                .AddParams(value.Id.ToString())
                .Build();

            opResult = dal.TryExecuteUpdate(query);
            if (!opResult)
            {
                Logger.Error("Can't remove record from call_history", query);
            }
            return opResult;
        }

        public void Update(CallHistoryItem value)
        {
            var historyID = value.Id.ToString();
            var contactID = value.Contact.Id.ToString();
            var callDirection = ((int)value.CallDirection).ToString();

            var query = queryBuilder.Add(Constants.DA_TRANSACTION_BEGIN)
                .Add(Environment.NewLine)
                // remove CallHistoryItem
                .Add(string.Format(Constants.DA_CALL_HISTORY_DELETE_VALUE_BY_ID_FMT, historyID))
                .Add(Environment.NewLine)
                // add new CallHistoryItem
                .Add(Constants.DA_CALL_HISTORY_INSERT_NEW_VALUES_FMT)
                .AddParams(contactID, callDirection)
                .Add(Environment.NewLine)
                .Add(Constants.DA_TRANSACTION_COMMIT)
                .Build();

            if (!dal.TryExecuteUpdate(query))
            {
                Logger.Error("Can't update record from call_history", query);
            }
        }
    }
}
