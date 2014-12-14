using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using PagedList;

namespace ZdtbSite.Core.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
        IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order, bool isDesc);
        T GetAsNoTracking(Expression<Func<T, bool>> where);
        IEnumerable<T> GetManyAsNoTracking(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAllAsNoTracking();
        IPagedList<T> GetPageAsNoTracking<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
    }
}
