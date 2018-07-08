using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.DataAccess
{
    public class Executor
    {
        private DbConnection connection;

        public Executor(DbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Execute update query, like 'insert', 'update' or etc.
        /// </summary>
        /// <param name="query"></param>
        public void ExecuteUpdate(String query)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            if (connection != null)
            {
                // create command statement
                var command = connection.CreateCommand();
                command.CommandText = query;
                int rows = command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Execute select query and return values, handled by 'handler'.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public T ExecuteQuery<T>(String query, Func<DataTable, T> handler)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            DataTable dataTable = new DataTable();
            if (connection != null)
            {
                // create command statement
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;

                dataTable.Load(command.ExecuteReader());

                if (dataTable.Rows.Count > 0)
                {
                    T result = handler(dataTable);
                    command.Dispose();
                    return result;
                }
            }
            return default(T);
        }
    }
}
