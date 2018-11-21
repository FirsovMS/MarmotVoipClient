using DAL;
using System.Linq;

namespace MarmotVoipClient.DataAccess
{
	public class BaseDAO
	{
		protected DataAccessLayer DAL { get; }
		protected readonly QueryBuilderInstance queryBuilder;

		public BaseDAO(DataAccessLayer dal)
		{
			DAL = dal;
			queryBuilder = new QueryBuilderInstance();
		}

		protected virtual bool CheckExists<T>(string tableName, string propertName, T value)
		{
			var query = string.Format(Constants.DA_CHECK_EXISTS_BY_PROP, tableName, propertName, value);
			return DAL.ExecuteQuery(query, (row) => (bool)row[0]).First();
		}
	}
}
