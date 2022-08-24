namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BaseUnitOfWork<T> : IBaseUnitOfWork<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _BaseRepsitory;

        public BaseUnitOfWork(IBaseRepository<T> baseRepository)
        {
            _BaseRepsitory = baseRepository;
        }

        public virtual async Task<List<T>> ReadAsync() => await _BaseRepsitory.GetAllAsync();

        public virtual async Task<T> ReadByIdAsync(Guid EntityId) => await _BaseRepsitory.GetByIdAsync(EntityId);

        public virtual async Task<T> CreateAsync(T entity)
        {
            entity = await _BaseRepsitory.AddAsync(entity);
            await _BaseRepsitory._dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            entity = await _BaseRepsitory.EditAsync(entity);
            await _BaseRepsitory._dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> DeleteAsync(Guid entityId)
        {
            T entity = await _BaseRepsitory.DeleteAsync(entityId);
            await _BaseRepsitory._dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
