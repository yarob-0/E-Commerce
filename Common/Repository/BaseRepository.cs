namespace Common
{
	using System;
	using System.Threading.Tasks;
	using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public DbContext _dbContext { get; }
        private readonly DbSet<T> _set;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id) {
			return await _set.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<List<T>> GetAllAsync() => await _set.ToListAsync();

        public virtual async Task<List<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression)
            => await _set.Where(expression).ToListAsync();

        public virtual async Task<T> AddAsync(T entity)
        {
            return (await _set.AddAsync(entity)).Entity;
        }

        public virtual async Task<T> EditAsync(T entity)
        {
            if (!await IsExists(entity))
                throw new Exception("Entity dosn't exist in database");

            return _set.Update(entity).Entity;
        }

        public virtual async Task<T> DeleteAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);
            if (entity is null)
                throw new Exception("Entity dosn't exist in database");

            _set.Remove(entity);
            
            return entity;
        }


        private async Task<bool> IsExists(Guid entityId)
        {
            return await _set.AnyAsync(e => e.Id == entityId);
        }

        private async Task<bool> IsExists(T entity)
        {
            return await _set.AnyAsync(p => p.Id == entity.Id);
        }
    }
}
