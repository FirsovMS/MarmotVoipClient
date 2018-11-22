using LoggingAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

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
			try
			{
				using (var command = Connection.CreateCommand())
				{
					command.CommandText = query;
					command.ExecuteNonQuery();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't execute TryExecuteUpdateAsync!", ex, Level.Error, query);
			}

			return result;
		}

		public IEnumerable<T> ExecuteQuery<T>(string query, Func<IDataReader, T> handleFactory)
		{
			var result = new List<T>();
			using (var command = Connection.CreateCommand())
			{
				command.CommandText = query;
				using (var reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							result.Add(handleFactory(reader));
						}
					}
				}
			}
			return result;
		}

		public async Task<bool> TryExecuteUpdateAsync(string query)
		{
			bool result = false;
			try
			{
				using (var command = Connection.CreateCommand())
				{
					command.CommandText = query;
					await command.ExecuteNonQueryAsync();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't execute TryExecuteUpdateAsync!", ex, Level.Error, query);
			}

			return result;
		}

		public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, Func<IDataReader, T> handleFactory)
		{
			var result = new List<T>();
			using (var command = Connection.CreateCommand())
			{
				command.CommandText = query;
				using (var reader = await command.ExecuteReaderAsync())
				{
					if (reader.HasRows)
					{
						while (await reader.ReadAsync())
						{
							result.Add(handleFactory(reader));
						}
					}
				}
			}
			return result;
		}
	}
}
