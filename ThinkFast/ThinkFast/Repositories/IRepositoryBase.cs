using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ThinkFast.Models;

namespace ThinkFast.Repositories
{
    public interface IRepositoryBase<T>
        where T : Entity, new()
    {
        bool Any();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null, int? top = null);
        TValue Max<TValue>(Func<T, TValue> predicate);
        int Count();
        T GetItem(int id);
        int DeleteItem(int id);
        int SaveItem(T item);
        int Clear();
    }
}