
namespace ECommerce
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryUnitOfWork _categoryUnitOfWork;

        protected Mapper _mapper;

        public CategoriesController(ICategoryUnitOfWork categoryUnitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BaseEntity<Category>, CategoryViewModel>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfiguration);
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get()
        {
			var entities = await _categoryUnitOfWork.ReadAsync();

			return Ok(entities.Select(category => _mapper.Map<CategoryViewModel>(category)));
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryUnitOfWork.ReadByIdAsync(id);
			CategoryViewModel categoryViewModel =
				_mapper.Map<CategoryViewModel>(category);

			FluentValidation.Results.ValidationResult validationResult = await
				new CategoryValidator().ValidateAsync(categoryViewModel);

            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            return Ok(categoryViewModel);
        }

        // POST api/<CategoriesController>
		[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Post([FromBody] Category category)
        {
            var cat = await _categoryUnitOfWork.CreateAsync(category);
            return Created("added", _mapper.Map<CategoryViewModel>(cat));
        }

        // PUT api/<CategoriesController>/5
		[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<CategoryViewModel>> Put([FromBody] Category category)
        {
            var cat = await _categoryUnitOfWork.UpdateAsync(category);
            return Created("changed", _mapper.Map<CategoryViewModel>(cat));
        }

        // DELETE api/<CategoriesController>/5
		[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _categoryUnitOfWork.DeleteAsync(id);
        }
    }
}
