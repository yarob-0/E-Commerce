namespace Common
{
    using System;
	using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseUnitOfWork<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T Entity);
        Task<T> DeleteAsync(Guid EntityId);
        Task<List<T>> ReadAsync();
        Task<T> ReadByIdAsync(Guid EntityId);
        Task<T> UpdateAsync(T Entity);
    }
}
