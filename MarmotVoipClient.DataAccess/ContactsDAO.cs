using DAL;
using LoggingAPI;
using MarmotVoipClient.Model.Data;
using QueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarmotVoipClient.DataAccess
{
	public class ContactsDAO : IBaseActions<Contact>
    {
        private readonly DataAccessLayer dal;
        private readonly QueryBuilderInstance queryBuilder;

        public ContactsDAO(DataAccessLayer dal)
        {
            this.dal = dal;
            queryBuilder = new QueryBuilderInstance();
        }

        public void Add(Contact value)
        {
            var query = queryBuilder.Add(Constants.DA_CONTACTS_INSERT_NEW_VALUES_FMT)
                .AddParams(value.FirstName, value.LastName, value.Sip, value.Email)
                .Build();

            if (!dal.TryExecuteUpdate(query))
            {
                Logger.Error("Can't add record to contacts", query);
            }
        }

        public bool TryGet(int id, out Contact value)
        {
            bool opResult = false;
            value = Contact.Default();

            var query = queryBuilder.Add(Constants.DA_CONTACTS_GET_BY_ID_FMT)
                .AddParams(id.ToString())
                .Build();

            try
            {
                var result = dal.ExecuteQuery(query, (row) => new Contact(
                (int)row["id"],
                (string)row["first_name"],
                (string)row["last_name"],
                (string)row["sip_url"],
                (string)row["email"]))
                .FirstOrDefault();

                opResult = result != null;
                if (opResult)
                {
                    value = result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Can't handle or get contact by ID!", query, exception: ex, logLevel: Level.Error);
            }
            return opResult;
        }

        public IEnumerable<Contact> GetAll()
        {
            IEnumerable<Contact> result = null;

            try
            {
                result = dal.ExecuteQuery(Constants.DA_CONTACTS_GET_ALL, (row) => new Contact(
                (int)row["id"],
                (string)row["first_name"],
                (string)row["last_name"],
                (string)row["sip_url"],
                (string)row["email"]));
            }
            catch (Exception ex)
            {
                Logger.Error("Can't get all contacts!", Constants.DA_CONTACTS_GET_ALL, exception: ex, logLevel: Level.Error);
            }
            return result;
        }

        public bool TryRemove(Contact value)
        {
            bool opResult = false;
            var query = string.Format(Constants.DA_CONTACTS_DELETE_VALUE_BY_ID_FMT, value.Id);

            opResult = dal.TryExecuteUpdate(query);
            if (!opResult)
            {
                Logger.Error("Can't remove contact by id!", query, logLevel: Level.Error);
            }
            return opResult;
        }

        public void Update(Contact value)
        {
            var query = queryBuilder.Add(Constants.DA_CONTACTS_UPDATE_VALUE_BY_ID_FMT)
                .AddParams(value.Id.ToString(), value.FirstName, value.LastName, value.Sip, value.Email)
                .Build();

            if (!dal.TryExecuteUpdate(query))
            {
                Logger.Error("Can't update contact!", query);
            }
        }
    }
}
