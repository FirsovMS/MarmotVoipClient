using System.Collections.Generic;

namespace MarmotVoipClient.DataAccess
{
    public interface IBaseActions<T>
    {
        bool TryGet(int id, out T value);

        IEnumerable<T> GetAll();

        bool TryAdd(T value);

        bool TryRemove(T value);

		bool TryUpdate(T value);
    }
}