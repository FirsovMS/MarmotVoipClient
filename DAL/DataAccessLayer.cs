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
			SQLiteCommand command = null;
			try
			{
				// create command statement
				command = Connection.CreateCommand();
				command.CommandText = query;
				command.ExecuteNonQuery();
				result = true;
			}
			catch (SQLiteException ex)
			{
				Logger.Error("Can't execute TryExecuteUpdate!", ex, Level.Error, query);
			}
			finally
			{
				command?.Dispose();
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
			catch (Exception ex)
			{
				Logger.Error($"Can't execute ExecuteQuery<{typeof(T)}>()!", ex, Level.Error, query);
			}
			finally
			{
				command?.Dispose();
			}

			return result;
		}

		public async Task<bool> TryExecuteUpdateAsync(string query)
		{
			bool result = false;
			SQLiteCommand command = null;
			try
			{
				// create command statement
				command = Connection.CreateCommand();
				command.CommandText = query;
				await command.ExecuteNonQueryAsync();
				result = true;
			}
			catch (SQLiteException ex)
			{
				Logger.Error("Can't execute TryExecuteUpdateAsync!", ex, Level.Error, query);
			}
			finally
			{
				command?.Dispose();
			}
			return result;
		}

		public async Task<IEnumerable<T>> ExecuteQuery<T>(string query, Func<DataRow, T> handleFactory)
		{
			var result = new List<T>();
			SQLiteCommand command = null;

			try
			{
				command = Connection.CreateCommand();
				command.CommandText = query;

				using (var reader = await command.ExecuteReaderAsync())
				{
					if (reader.HasRows)
					{
						var dt = new DataTable();
						dt.Load(reader);
						result.AddRange(dt.AsEnumerable().Select(row => handleFactory(row)));
						return result;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Error($"Can't execute ExecuteQuery<{typeof(T)}>!", ex, Level.Error, query);
			}
			finally
			{
				command?.Dispose();
			}

			return result;
		}

		~DataAccessLayer()
		{
			Connection?.Close();
		}
	}
}
