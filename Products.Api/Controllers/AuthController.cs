using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.User;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services.Config;
using Products.Domain.Responses;
using Products.Domain.Responses.@base;

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

        [HttpPost]
        public async Task<ActionResult<BaseResponse<UserAuthResponse>>> Login(UserDTO request)
        {
            try
            {
                bool verifyPassword = _service.VerifyPasswordHash(request);

                if (!verifyPassword)
                {
                    return BadRequest("Wrong password");
                }

                string token = _service.CreateToken(request);

                UserAuthResponse userAuthResponse = new()
                {
                    Token = token,
                    ExpiresIn = 28000,
                };

                BaseResponse<UserAuthResponse> response = new()
                {
                    Message = "Logged in!",
                    Content = userAuthResponse,
                };

                return Ok(response);
            }
            catch (UserNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }
        [HttpPost("/api/Auth/Data"), Authorize]
        public async Task<ActionResult<BaseResponse<UserAuthResponseDTO>>> DecodeData(string request)
        {
            try
            {
                var user = _service.GetUserFromJwt(request);

                BaseResponse<UserAuthResponseDTO> response = new()
                {
                    Message = "Success, user found!",
                    Content = user,
                };

                return Ok(response);
            }
            catch (UserNotFoundException error)
            {
                return NotFound(error.Message);
            }

        }
    }
}
