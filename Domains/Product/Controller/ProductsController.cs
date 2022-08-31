
namespace Domains.Product
{
	using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product>
    {
        public ProductsController(IProductUnitOfWork productUnitOfWork) : base(productUnitOfWork)
        {
        }
    }
}
