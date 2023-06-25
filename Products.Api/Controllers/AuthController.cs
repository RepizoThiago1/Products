using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.User;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services.Config;
using Products.Domain.Responses;
using Products.Domain.Responses.@base;
using System.Net;
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
                    var response = BaseResponse<UserAuthResponse>.ToResponse(HttpStatusCode.BadRequest, "Wrong password");

                    return response;
                }

                bool isConfirmKeyActive = _service.VerifyConfirmedKey(request.Email);

                if (isConfirmKeyActive)
                {
                    var token = _service.CreateToken(request);

                    var content = UserAuthResponse.ToResponse(token, 28000);

                    var response = BaseResponse<UserAuthResponse>.ToResponse(HttpStatusCode.OK, "Logged in!", content);

                    return response;
                }
                else
                {
                    var message = "Account not able to use our services, please confirm your account first";

                    var response = BaseResponse<UserAuthResponse>.ToResponse(HttpStatusCode.BadRequest, message);

                    return response;
                }

            }
            catch (UserNotFoundException error)
            {
                var response = BaseResponse<UserAuthResponse>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }
        }
        [HttpPost("/api/Auth/Data"), Authorize]
        public async Task<ActionResult<BaseResponse<UserAuthResponseDTO>>> DecodeData(string request)
        {
            try
            {
                var user = _service.GetUserFromJwt(request);

                var response = BaseResponse<UserAuthResponseDTO>.ToResponse(HttpStatusCode.OK, "Success, user found!", user);

                return response;
            }
            catch (UserNotFoundException error)
            {
                var response = BaseResponse<UserAuthResponseDTO>.ToResponse(HttpStatusCode.NotFound, error.Message);

                return response;
            }

        }
    }
}
