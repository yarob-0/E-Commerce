namespace ECommerce
{
    public class ProductUnitOfWork :IProductUnitOfWork
    {
        private readonly IProductRepository _prodcutRepsitory;

        public ProductUnitOfWork(IProductRepository prodcutRepsitory)
        {
            _prodcutRepsitory = prodcutRepsitory;
        }

        public async Task<List<Product>> ReadAsync()
        {
            return await _prodcutRepsitory.GetAllAsync();
        }

        public async Task<Product> ReadByIdAsync(Guid productId)
        {
            return await _prodcutRepsitory.GetByIdAsync(productId);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product = await _prodcutRepsitory.AddAsync(product);
            await _prodcutRepsitory.DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            product = await _prodcutRepsitory.EditAsync(product);
            await _prodcutRepsitory.DbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteAsync(Guid productId)
        {
            Product product = await _prodcutRepsitory.DeleteAsync(productId);
            await _prodcutRepsitory.DbContext.SaveChangesAsync();
            return product;
        }
    }
}