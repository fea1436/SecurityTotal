using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _00_Framework.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        T Get(TKey id);
        List<T> Get();
        void SaveChanges();
        void Create(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
