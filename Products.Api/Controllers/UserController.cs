using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.User;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;
using System.Net;

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

                var response = BaseResponse<string>.ToResponse(HttpStatusCode.Accepted, "Key validated!");

                return Ok(response);

            }
            catch (UserNotFoundException error)
            {
                var response = BaseResponse<string>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }
            catch (InvalidConfirmKeyException error)
            {
                var response = BaseResponse<string>.ToResponse(HttpStatusCode.Conflict, error.Message);

                return response;
            }
        }

        [HttpPost]
        public ActionResult<BaseResponse<UserDTO>> Register(UserDTO request)
        {
            try
            {
                var registerService = _service.Register(request);

                var content = UserDTO.FromEntity(registerService.Email, request.Password);

                var response = BaseResponse<UserDTO>.ToResponse(HttpStatusCode.Created, "User created!", content);

                return response;
            }
            catch (UserAlreadyExistsException error)
            {
                var response = BaseResponse<UserDTO>.ToResponse(HttpStatusCode.UnprocessableEntity, error.Message);

                return response;
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

                var response = BaseResponse<string>.ToResponse(HttpStatusCode.Continue, "An e-mail was sent to your e-mail address");

                return response;
            }
            catch (UserNotFoundException error)
            {
                var response = BaseResponse<string>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ActionResult<BaseResponse<User>> EditUserRole(UpdateUserDTO request)
        {
            try
            {
                var user = _service.UpdateRole(request);

                var response = BaseResponse<User>.ToResponse(HttpStatusCode.OK, "User updated!", user);

                return response;
            }
            catch (UserNotFoundException error)
            {
                var response = BaseResponse<User>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }

        }
    }
}
