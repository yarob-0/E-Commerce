namespace Product
{
	using Common;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : BaseRepository<Product> ,IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
