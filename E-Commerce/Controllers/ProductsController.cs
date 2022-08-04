// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

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
        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            List<Product> entities = await _productUnitOfWork.ReadAsync();
            return entities.Select(product => _mapper.Map<ProductViewModel>(product));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Product product = await _productUnitOfWork.ReadByIdAsync(id);
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product);

            FluentValidation.Results.ValidationResult validationResult = await new ProductValidator().ValidateAsync(productViewModel);

            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            return Ok(productViewModel);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ProductViewModel> Post([FromBody] Product product)
        {
            product = await _productUnitOfWork.CreateAsync(product);
            return _mapper.Map<ProductViewModel>(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<ProductViewModel> Put([FromBody] Product product)
        {
            product = await _productUnitOfWork.UpdateAsync(product);
            return _mapper.Map<ProductViewModel>(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _productUnitOfWork.DeleteAsync(id);
        }
    }
}