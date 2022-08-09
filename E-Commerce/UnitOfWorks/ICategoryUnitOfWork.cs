namespace ECommerce
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryUnitOfWork
    {
        Task<Category> CreateAsync(Category cat);
        Task<Category> DeleteAsync(Guid catId);
        Task<List<Category>> ReadAsync();
        Task<Category> ReadByIdAsync(Guid catId);
        Task<Category> UpdateAsync(Category cat);
    }
}
