using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.User;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("user")]
        public ActionResult<User> Register(UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("User is null");

            var user = _service.Register(userDTO);
            return Ok(user);
        }
    }
}
