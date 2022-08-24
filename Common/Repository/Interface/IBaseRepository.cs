namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbContext _dbContext { get; }

        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(Guid id);
        Task<T> EditAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);
    }
}
