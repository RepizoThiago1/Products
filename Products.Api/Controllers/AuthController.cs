﻿using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.User;
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
        public async Task<ActionResult<BaseResponse<UserAuthResponse>>> Login(UserDTO RequestUserDTO)
        {
            try
            {

                bool verifyPassword = _service.VerifyPasswordHash(RequestUserDTO);

                if (!verifyPassword)
                {
                    return BadRequest("Wrong password");
                }
                
                string token = _service.CreateToken(RequestUserDTO);

                UserAuthResponse userAuthResponse = new()
                {
                    Token = token,
                    ExpiresIn = DateTime.UtcNow.AddHours(8)
                };

                BaseResponse<UserAuthResponse> response = new()
                {
                    Message = "Logged in!",
                    Content = userAuthResponse,
                };

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
