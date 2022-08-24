namespace ECommerce
{
	using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category>
    {
        public CategoriesController(ICategoryUnitOfWork categoryUnitOfWork) : base(categoryUnitOfWork)
        {
        }
    }
}
