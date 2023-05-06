using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.User;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
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

        [HttpPost]
        public ActionResult<User> Register(UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return BadRequest("User is null");

                var user = _service.Register(userDTO);
                return Ok(user);
            }
            catch (UserAlreadyExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ActionResult<User> EditUserRole(UpdateUserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("User null");

            var user = _service.UpdateRole(userDTO);
            return Ok(user);
        }
    }
}
