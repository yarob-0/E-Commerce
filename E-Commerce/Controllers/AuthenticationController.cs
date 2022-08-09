
namespace ECommerce
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authentication;

        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AuthenticationModel requstedModel = await _authentication.RegisterAsync(model);

            if (!requstedModel.IsAuthenticated)
                return BadRequest(requstedModel.Message);

            return Created("registered user", requstedModel);
        }

        [HttpGet("Token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AuthenticationModel requstedModel = await _authentication.GetTokenAsync(model);

            if (!requstedModel.IsAuthenticated)
                return BadRequest(requstedModel.Message);

            return Ok(requstedModel);
        }

		[Authorize]
        [HttpDelete("Unregister")]
		public async Task<IActionResult> UnregisterAsync([FromBody]
				TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

			AuthenticationModel requstedModel = await
				_authentication.UnregisterAsync(model);

            return requstedModel.IsAuthenticated ? Ok(requstedModel) : BadRequest(requstedModel);
        }

		[Authorize(Roles = "Admin")]
        [HttpPost("SetRole")]
        public async Task<IActionResult> SetRoleAsync([FromBody] SetRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string rtn = await _authentication.SetRoleAsync(model);

            if (!string.IsNullOrEmpty(rtn))
                return BadRequest(rtn);

            return Created("registered user", rtn);
        }
    }
}
