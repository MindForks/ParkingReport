using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PR.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void SaveChanges();
    }
}