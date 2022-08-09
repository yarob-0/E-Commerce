namespace ECommerce
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface ICategoryRepository
    {
        ApplicationDbContext DbContext { get; }

        Task<Category> AddAsync(Category cat);
        Task<Category> DeleteAsync(Guid id);
        Task<Category> EditAsync(Category cat);
        Task<List<Category>> GetAllAsync();
        Task<List<Category>> GetByExprissionAsync(Expression<Func<Category, bool>> expression);
        Task<Category> GetByIdAsync(Guid id);
    }
}
