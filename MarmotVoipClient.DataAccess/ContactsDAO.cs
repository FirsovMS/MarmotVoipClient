using DAL;
using LoggingAPI;
using MarmotVoipClient.Model.Data;
using QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data;
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

		public bool TryAdd(Contact value)
		{
			var query = queryBuilder.Add(Constants.DA_CONTACTS_INSERT_NEW_VALUES_FMT)
				.AddParams(value.Id.ToString(), value.FirstName, value.LastName, value.Sip)
				.Build();

			return dal.TryExecuteUpdate(query);
		}

		public bool TryGet(string sip, out Contact value)
		{
			bool opResult = false;
			value = Contact.Default();

			var query = queryBuilder.Add(Constants.DA_CONTACTS_GET_BY_SIP_FMT)
				.AddParams(sip)
				.Build();

			try
			{
				var result = dal.ExecuteQuery(query, row => ContactHandler(row))
				.FirstOrDefault();

				opResult = result != null;
				if (opResult)
				{
					value = result;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get contact by sip!", query, exception: ex, logLevel: Level.Error);
			}
			return opResult;
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
				var result = dal.ExecuteQuery(query, row => ContactHandler(row))
				.FirstOrDefault();

				opResult = result != null;
				if (opResult)
				{
					value = result;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get contact by id!", query, exception: ex, logLevel: Level.Error);
			}
			return opResult;
		}

		public IEnumerable<Contact> GetAll()
		{
			IEnumerable<Contact> result = null;

			try
			{
				result = dal.ExecuteQuery(Constants.DA_CONTACTS_GET_ALL, row => ContactHandler(row));
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

		public bool TryUpdate(Contact value)
		{
			var query = queryBuilder.Add(Constants.DA_CONTACTS_UPDATE_VALUE_BY_ID_FMT)
				.AddParams(value.Id.ToString(), value.FirstName, value.LastName, value.Sip)
				.Build();

			return dal.TryExecuteUpdate(query);
		}

		private bool TryGet<T>(string query, out Contact value)
		{
			bool opResult = false;
			value = Contact.Default();

			try
			{
				var result = dal.ExecuteQuery(query, row => ContactHandler(row))
				.FirstOrDefault();

				opResult = result != null;
				if (opResult)
				{
					value = result;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't handle or get contact!", query, exception: ex, logLevel: Level.Error);
			}
			return opResult;
		}

		private static Contact ContactHandler(DataRow row)
		{
			return new Contact(
				Convert.ToInt32(row["contact_id"]),
				(string)row["first_name"],
				(string)row["last_name"],
				(string)row["sip"]);
		}
	}
}
