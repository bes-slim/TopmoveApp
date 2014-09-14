using System.Collections.Generic;

namespace TopMove.Lettings.Context.Accounts.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> List();
    }
}