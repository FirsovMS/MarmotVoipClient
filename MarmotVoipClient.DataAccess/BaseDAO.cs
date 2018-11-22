using DAL;
using System.Linq;
using System.Threading.Tasks;

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

		protected virtual async Task<bool> CheckExistsAsync<T>(string tableName, string propertName, T value)
		{
			var query = string.Format(Constants.DA_CHECK_EXISTS_BY_PROP, tableName, propertName, value);
			return (await DAL.ExecuteQueryAsync(query, (row) => (bool)row[0])).First();
		}
	}
}
