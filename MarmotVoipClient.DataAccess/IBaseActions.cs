using System.Collections.Generic;

namespace MarmotVoipClient.DataAccess
{
    public interface IBaseActions<T>
    {
        bool TryGet(int id, out T value);

        IEnumerable<T> GetAll();

        void Add(T value);

        bool TryRemove(T value);

        void Update(T value);
    }
}