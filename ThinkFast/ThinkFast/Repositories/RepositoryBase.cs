using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLite;
using ThinkFast.Models;

namespace ThinkFast.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity, new()
    {
        private readonly SQLiteConnection database;

        public RepositoryBase(SQLiteConnection database)
        {
            this.database = database;
        }

        public bool Any()
        {
            return database.Table<T>().Any();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null, int? top = null)
        {
            var query = database.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (top != null)
                query = query.OrderByDescending(x=>x.Id).Take(top.Value);

            return query.ToList();
        }

        public TValue Max<TValue>(Func<T, TValue> predicate)
        {
            return database.Table<T>().Max(predicate);
        }

        public T GetItem(int id)
        {
            return database.Get<T>(id);
        }

        public int Count(Func<T, bool> predicate = null)
        {
            return predicate == null 
            ? database.Table<T>().Count()
            : database.Table<T>().Count(predicate);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<T>(id);
        }
        public int SaveItem(T item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public int Clear()
        {
            return database.DeleteAll<T>();
        }
    }
}