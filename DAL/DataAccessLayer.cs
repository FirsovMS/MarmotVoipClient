using LoggingAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DAL
{
    public class DataAccessLayer
    {
        private Lazy<SQLiteConnection> lazyConnection;

        public DataAccessLayer()
        {
            lazyConnection = new Lazy<SQLiteConnection>(
                () => new SQLiteConnection());
        }

        public bool TryExecuteUpdate(string query)
        {
            bool result = false;
            SQLiteCommand command = null;
            try
            {
                // create command statement
                command = lazyConnection.Value.CreateCommand();
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
                lazyConnection.Value?.Close();
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
                command = lazyConnection.Value.CreateCommand();
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
                lazyConnection.Value?.Close();
            }

            return result;
        }
    }
}
