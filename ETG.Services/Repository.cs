using ETG.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETG.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _dbSet;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = unitOfWork.Set<T>();
        }

        public IEnumerable<T> All()
        {
            return _dbSet.AsEnumerable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsEnumerable();

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            _dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
