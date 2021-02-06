using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Book_Store.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        //Gan cac tham so mac dinh bang null
        //Expression dai dien cho bieu thuc Lambda => chuyen thanh Cay bieu thuc, bien lai thanh Func hoac Action bang .Compile()
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
                              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                              string includeProperties = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
                              string includeProperties = null);

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
    }
}
