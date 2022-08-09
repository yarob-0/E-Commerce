namespace ECommerce
{
    public class CategoryUnitOfWork :ICategoryUnitOfWork
    {
        private readonly ICategoryRepository _prodcutRepsitory;

        public CategoryUnitOfWork(ICategoryRepository prodcutRepsitory)
        {
            _prodcutRepsitory = prodcutRepsitory;
        }

        public async Task<List<Category>> ReadAsync()
        {
            return await _prodcutRepsitory.GetAllAsync();
        }

        public async Task<Category> ReadByIdAsync(Guid catId)
        {
            return await _prodcutRepsitory.GetByIdAsync(catId);
        }

        public async Task<Category> CreateAsync(Category cat)
        {
            cat = await _prodcutRepsitory.AddAsync(cat);
            await _prodcutRepsitory.DbContext.SaveChangesAsync();
            return cat;
        }

        public async Task<Category> UpdateAsync(Category cat)
        {
            cat = await _prodcutRepsitory.EditAsync(cat);
            await _prodcutRepsitory.DbContext.SaveChangesAsync();
            return cat;
        }

        public async Task<Category> DeleteAsync(Guid catId)
        {
            Category cat = await _prodcutRepsitory.DeleteAsync(catId);
            await _prodcutRepsitory.DbContext.SaveChangesAsync();
            return cat;
        }
    }
}
