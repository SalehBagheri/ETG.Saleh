using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETG.Services
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        Task<T> GetById(Guid id);
        Task Insert(T entity);
        Task Remove(object id);
        Task Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
