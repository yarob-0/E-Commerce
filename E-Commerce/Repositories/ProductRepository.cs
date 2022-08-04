namespace ECommerce
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    public class ProductRepository : IProductRepository
    {
        public ApplicationDbContext DbContext { get; }
        private readonly DbSet<Product> _products;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _products = DbContext.Set<Product>();
        }

        public async Task<Product> GetByIdAsync(Guid id) => await _products.FirstOrDefaultAsync(p => p.Id == id);
        public virtual async Task<List<Product>> GetAllAsync() => await _products.ToListAsync();
        public virtual async Task<List<Product>> GetByExprissionAsync(Expression<Func<Product, bool>> expression)
            => await _products.Where(expression).ToListAsync();

        public virtual async Task<Product> AddAsync(Product product)
        {
            return (await _products.AddAsync(product)).Entity;
        }
        public virtual async Task<Product> EditAsync(Product product)
        {
            if (!await IsExists(product))
                throw new Exception("Entity dosn't exist in database");

            return _products.Update(product).Entity;
        }
        public virtual async Task<Product> DeleteAsync(Guid id)
        {
            Product product = await GetByIdAsync(id);
            if (product is null)
                throw new Exception("Entity dosn't exist in database");

            _products.Remove(product);
            
            return product;
        }


        private async Task<bool> IsExists(Guid productId)
        {
            return await _products.AnyAsync(p => p.Id == productId);
        }
        private async Task<bool> IsExists(Product product)
        {
            return await _products.AnyAsync(p => p.Id == product.Id);
        }
    }
}