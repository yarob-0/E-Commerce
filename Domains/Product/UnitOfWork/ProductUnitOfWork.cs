namespace Domains.Product
{
	using Common;
    public class ProductUnitOfWork : BaseUnitOfWork<Product>, IProductUnitOfWork
    {
        public ProductUnitOfWork(IProductRepository productRepository) : base(productRepository)
        {
        }
    }
}
