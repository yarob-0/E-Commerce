
namespace Common
{
	using System;
	using System.Threading.Tasks;
	using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IBaseUnitOfWork<T> _baseUnitOfWork;

        protected Mapper _mapper;

        public BaseController(IBaseUnitOfWork<T> baseUnitOfWork)
        {
            _baseUnitOfWork = baseUnitOfWork;

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BaseEntity, BaseEntityViewModel>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfiguration);
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseEntityViewModel>>> Get()
        {
			var entities = await _baseUnitOfWork.ReadAsync();
			return Ok(entities.Select(e =>
					_mapper.Map<BaseEntityViewModel>(e)));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _baseUnitOfWork.ReadByIdAsync(id);

			BaseEntityViewModel viewModel =
				_mapper.Map<BaseEntityViewModel>(entity);

			FluentValidation.Results.ValidationResult validationResult = await
				new BaseValidator<BaseEntityViewModel>().ValidateAsync(viewModel);

            if (!validationResult.IsValid)
                return BadRequest(new { errors = validationResult.Errors });

            return Ok(viewModel);
        }

        // POST api/<ProductsController>
		[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<BaseEntityViewModel>> Post([FromBody] T entity)
        {
            var ent = await _baseUnitOfWork.CreateAsync(entity);
            return Created(entity.Id.ToString(), _mapper.Map<BaseEntityViewModel>(ent));
        }

        // PUT api/<entitysController>/5
		[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<BaseEntityViewModel>> Put([FromBody] T entity)
        {
            var ent = await _baseUnitOfWork.UpdateAsync(entity);
            return Created(entity.Id.ToString(), _mapper.Map<BaseEntityViewModel>(ent));
        }

        // DELETE api/<entitysController>/5
		[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _baseUnitOfWork.DeleteAsync(id);
        }
    }
}
