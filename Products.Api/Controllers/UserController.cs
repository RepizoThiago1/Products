using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.User;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMailerService _mailerService;

        public UserController(IUserService service, IMailerService mailerService)
        {
            _service = service;
            _mailerService = mailerService;
        }

        [HttpPost("/api/[controller]/Validate")]
        public ActionResult<BaseResponse<string>> ValidateUser(string key)
        {
            try
            {
                _service.ValidateConfirmKey(key);
                BaseResponse<string> response = new()
                {
                    Message = "Now you're able to use our services!"
                };

                return Ok(response);

            }
            catch (UserNotFoundException error)
            {
                return NotFound(error.Message);
            }
            catch (InvalidConfirmKeyException error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPost]
        public ActionResult<BaseResponse<UserDTO>> Register(UserDTO request)
        {
            try
            {
                if (request == null)
                    return BadRequest("User is null");

                var user = _service.Register(request);

                BaseResponse<UserDTO> response = new()
                {
                    Message = "Registered!",
                    Content = request
                };

                return Ok(response);
            }
            catch (UserAlreadyExistsException error)
            {
                return UnprocessableEntity(error.Message);
            }
            catch (EmptyPasswordException error)
            {
                return BadRequest(error.Message);
            }
            catch (EmptyEmailException error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("/api/[controller]/ForgotPassword")]
        public ActionResult<BaseResponse<string>> Email(string request)
        {
            try
            {
                _mailerService.ForgotPassword(request);

                return Ok("heheboy");
            }
            catch (UserNotFoundException error)
            {
                return BadRequest(error.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ActionResult<BaseResponse<User>> EditUserRole(UpdateUserDTO request)
        {
            try
            {
                if (request == null)
                    return BadRequest("User null");

                var user = _service.UpdateRole(request);

                BaseResponse<User> response = new()
                {
                    Message = "",
                    Content = user
                };

                return Ok(response);
            }
            catch (UserNotFoundException error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
