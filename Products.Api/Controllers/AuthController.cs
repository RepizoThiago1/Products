using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO;
using Products.Domain.Interfaces.Services.Config;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserDTO RequestUserDTO)
        {
            bool verifyPassword = _service.VerifyPasswordHash(RequestUserDTO);

            if (!verifyPassword)
            {
                return BadRequest("Wrong password");
            }

            string token = _service.CreateToken(RequestUserDTO);

            return Ok(token);
        }
    }
}
