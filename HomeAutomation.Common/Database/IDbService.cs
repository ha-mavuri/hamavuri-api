using System.Collections.Generic;

namespace HomeAutomation.Common.Database
{
    public interface IDbService<T> where T : class
    {
        void Delete(T t);
        void Delete(string id);
        T Get(string id);
        List<T> GetAll();
        T Insert(T t);
        bool Update(string id, T t);

    }
}
