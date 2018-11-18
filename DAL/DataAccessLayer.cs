using LoggingAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DAL
{
	public class DataAccessLayer
	{
		private SQLiteConnection Connection;

		public ConnectionState ConnectionStatus => Connection.State;

		public DataAccessLayer(string connectionString)
		{
			Connection = new SQLiteConnection(connectionString);
			Connection.Open();
		}

		public bool TryExecuteUpdate(string query)
		{
			bool result = false;
			SQLiteCommand command = null;
			try
			{
				// create command statement
				command = Connection.CreateCommand();
				command.CommandText = query;
				result = command.ExecuteNonQuery() == 0;
			}
			catch (SQLiteException ex)
			{
				Logger.Error("Can't execute query!", query, ex, Level.Error);
			}
			finally
			{
				command?.Dispose();
				Connection?.Close();
			}
			return result;
		}

		public IEnumerable<T> ExecuteQuery<T>(string query, Func<DataRow, T> handleFactory)
		{
			var result = new List<T>();
			SQLiteCommand command = null;

			try
			{
				var dt = new DataTable();
				command = Connection.CreateCommand();
				command.CommandText = query;

				dt.Load(command.ExecuteReader());

				if (dt.Rows.Count > 0)
				{
					result.AddRange(dt.AsEnumerable().Select(row => handleFactory(row)));
					return result;
				}
			}
			catch (SQLiteException ex)
			{
				Logger.Error("Can't execute query!", query, ex, Level.Error);
			}
			finally
			{
				command?.Dispose();
				Connection?.Close();
			}

			return result;
		}
	}
}
