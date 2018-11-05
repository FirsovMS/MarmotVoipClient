using System.Text;

namespace QueryBuilder
{
    public class QueryBuilderInstance
    {
        private StringBuilder builder;

        public QueryBuilderInstance()
        {
            builder = new StringBuilder();
        }

        public QueryBuilderInstance Add(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                builder.Append(str);
            }
            return this;
        }

        public QueryBuilderInstance AddParams(params string[] vars)
        {
            var template = builder.ToString();
            builder.Clear();
            builder.AppendFormat(template, vars);
            return this;
        }

        /// <summary>
        /// Build querry and clear builder
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            var result = builder.ToString();
            builder.Clear();
            return result;
        }
    }
}
