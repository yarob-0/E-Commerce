
namespace ECommerce
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductUnitOfWork _productUnitOfWork;

        protected Mapper _mapper;

        public ProductsController(IProductUnitOfWork productUnitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfiguration);
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Get()
        {
			var entities = await _productUnitOfWork.ReadAsync();
			return Ok(entities.Select(product =>
					_mapper.Map<ProductViewModel>(product)));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productUnitOfWork.ReadByIdAsync(id);
			ProductViewModel productViewModel =
				_mapper.Map<ProductViewModel>(product);

			FluentValidation.Results.ValidationResult validationResult = await
				new ProductValidator().ValidateAsync(productViewModel);

            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            return Ok(productViewModel);
        }

        // POST api/<ProductsController>
		[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Post([FromBody] Product product)
        {
            var pro = await _productUnitOfWork.CreateAsync(product);
            return Created(product.Id.ToString(), _mapper.Map<ProductViewModel>(pro));
        }

        // PUT api/<ProductsController>/5
		[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<ProductViewModel>> Put([FromBody] Product product)
        {
            var pro = await _productUnitOfWork.UpdateAsync(product);
            return Created(product.Id.ToString(), _mapper.Map<ProductViewModel>(pro));
        }

        // DELETE api/<ProductsController>/5
		[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _productUnitOfWork.DeleteAsync(id);
        }
    }
}
