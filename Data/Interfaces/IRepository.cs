using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Add(T entity);
        IEnumerable<T> Where(Func<T, bool> predicate);
        void Remove(T entity);
    }
}
