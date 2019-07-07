﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Get(Guid id);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
