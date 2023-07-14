using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CourseMicroSerivce.Domain;
using Microsoft.EntityFrameworkCore;
using Project.BusinessAccessLayer.Repositories;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.GenericRepository
{
    public class GenericRepository<T> : IRepo<T> where T : class
    {
        private readonly Coursecontext _CourseContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(Coursecontext coursecontext)
        {
            _CourseContext = coursecontext;
            _dbSet = _CourseContext.Set<T>();
        }

        public GenericRepository(CourseContent courseContent)
        {
            CourseContent = courseContent;
        }

        public CourseContent CourseContent { get; }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> Remove(int id)
        {
            var GernericeEntitiy = await _dbSet.FindAsync(id);
            if (GernericeEntitiy != null)
            {
                _dbSet.Remove(GernericeEntitiy);
                return true;
            }
            return false;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _CourseContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
