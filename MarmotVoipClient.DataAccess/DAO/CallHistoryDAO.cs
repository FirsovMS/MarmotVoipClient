using MarmotVoipClient.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MarmotVoipClient.DataAccess.DAO
{
    public class CallHistoryDAO
    {
        private readonly Executor executor;

        public CallHistoryDAO(Executor executor)
        {
            this.executor = executor;
        }

        public List<CallHistoryItem> GetAllHistory()
        {
            try
            {
               return executor.ExecuteQuery(
                "SELECT * FROM CallHistory;",
                (dt) =>
                {
                    return dt.AsEnumerable()
                     .Select(row =>
                     {
                         var item = new CallHistoryItem
                         {
                             Id = int.Parse(row["Id"].ToString()),
                             Phone = row["Phone"].ToString(),
                             PersonId = int.Parse(row["PersonId"].ToString()),
                             CallStarted = DateTime.Parse(row["CallStarted"].ToString()),
                             CallEnded = DateTime.Parse(row["CallEnded"].ToString()),
                             CallType = (CallType)int.Parse(row["CallType"].ToString())
                         };
                         // return new HistoryItem
                         return item;
                     }).ToList();
                });
            } catch(Exception e)
            {
                
            }
            return null;
        }

        public CallHistoryItem GetItem(int id)
        {
            try
            {
                if (id < 0)
                    throw new Exception("Id can't be lower 0");

                return executor.ExecuteQuery<CallHistoryItem>(
                 $"SELECT * FROM CallHistory WHERE Id = {id};",
                 (dt) =>
                 {
                     var row = dt.Rows[0];
                     var item = new CallHistoryItem
                     {
                         Id = int.Parse(row["Id"].ToString()),
                         Phone = row["Phone"].ToString(),
                         PersonId = int.Parse(row["PersonId"].ToString()),
                         CallStarted = DateTime.Parse(row["CallStarted"].ToString()),
                         CallEnded = DateTime.Parse(row["CallEnded"].ToString()),
                         CallType = (CallType)int.Parse(row["CallType"].ToString())
                     };
                     return item;
                 });
            }
            catch
            {
                return null;
            }            
        }

        public void InsertNewItem(CallHistoryItem item)
        {
            try
            {
                executor.ExecuteUpdate(
                    $"INSERT INTO CallHistory VALUES({item.Id}, '{item.Phone}', {item.PersonId}, '{item.CallStarted}', '{item.CallEnded}', {(int)item.CallType});");
            }
            catch (Exception e)
            {

            }
        }

        public void DeleteItem(int id)
        {
            if (id < 0)
                throw new Exception("Id can't be lower 0");

            executor.ExecuteUpdate(
                $"DELETE FROM CallHistory WHERE Id={id} LIMIT 1;");
        }
    }
}
