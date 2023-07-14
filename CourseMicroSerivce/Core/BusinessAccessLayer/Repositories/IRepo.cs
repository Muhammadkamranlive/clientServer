using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.BusinessAccessLayer.Repositories
{
   public interface IRepo<T>  where T: class
    {
        Task<T?> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task<bool> Remove(int id);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
