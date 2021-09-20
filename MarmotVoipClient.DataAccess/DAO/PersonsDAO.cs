using MarmotVoipClient.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.DataAccess.DAO
{
    public class PersonsDAO
    {
        private Executor executor;

        public PersonsDAO(Executor executor)
        {
            this.executor = executor;
        }

        public Person GetPerson(int id)
        {
            try
            {
                if (id < 0)
                    throw new Exception("Id can't be lower 0");

                return this.executor.ExecuteQuery(
                    $"SELECT * FROM Persons WHERE PersonId={id};",
                    (dt) =>
                    {
                        var row = dt.Rows[0];
                        return new Person()
                        {
                            PersonId = int.Parse(row["PersonId"].ToString()),
                            FirstName = row["FirstName"].ToString(),
                            LastName = row["LastName"].ToString()
                        };
                    });
            }
            catch (Exception e)
            {
                
            }
            return null;
        }

        public List<Person> GetAll()
        {
            try
            {
                var a = executor.ExecuteQuery(
                    "SELECT * FROM Persons;",
                    (dt) =>
                    {
                       return dt.AsEnumerable()
                        .Select(row => new Person()
                        {
                            PersonId = int.Parse(row["PersonId"].ToString()),
                            FirstName = row["FirstName"].ToString(),
                            LastName = row["LastName"].ToString()
                        }).ToList();
                    });
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public void InsertPerson(Person person)
        {
            try
            {
                executor.ExecuteUpdate(
                    $"INSERT INTO Persons VALUES({person.PersonId}, '{person.FirstName}', '{person.LastName}');");
            }
            catch (Exception e)
            {

            }
        }
    }
}
