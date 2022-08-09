namespace ECommerce
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class CategoryRepository : ICategoryRepository
    {
        public ApplicationDbContext DbContext { get; }
        private readonly DbSet<Category> _cats;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _cats = DbContext.Set<Category>();
        }

        public async Task<Category> GetByIdAsync(Guid id) => await _cats.FirstOrDefaultAsync(p => p.Id == id);
        public virtual async Task<List<Category>> GetAllAsync() => await _cats.ToListAsync();
        public virtual async Task<List<Category>> GetByExprissionAsync(Expression<Func<Category, bool>> expression)
            => await _cats.Where(expression).ToListAsync();

        public virtual async Task<Category> AddAsync(Category cat)
        {
            return (await _cats.AddAsync(cat)).Entity;
        }
        public virtual async Task<Category> EditAsync(Category cat)
        {
            if (!await IsExists(cat))
                throw new Exception("Entity dosn't exist in database");

            return _cats.Update(cat).Entity;
        }
        public virtual async Task<Category> DeleteAsync(Guid id)
        {
            Category cat = await GetByIdAsync(id);
            if (cat is null)
                throw new Exception("Entity dosn't exist in database");

            _cats.Remove(cat);
            
            return cat;
        }


        private async Task<bool> IsExists(Guid catId)
        {
            return await _cats.AnyAsync(p => p.Id == catId);
        }
        private async Task<bool> IsExists(Category cat)
        {
            return await _cats.AnyAsync(p => p.Id == cat.Id);
        }
    }
}
