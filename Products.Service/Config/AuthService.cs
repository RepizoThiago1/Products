using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products.Domain.DTO.User;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services.Config;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Products.Service.Config
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository repository, IConfiguration configuration, IUserRepository userRepository)
        {
            _repository = repository;
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public string CreateToken(UserDTO userDTO)
        {
            var user = _repository.Find(x => x.Email == userDTO.Email).FirstOrDefault();

            var token = CreateToken(user);
            return token;
        }

        public bool VerifyPasswordHash(UserDTO userDTO)
        {
            var user = _repository.Find(x => x.Email == userDTO.Email).FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            return VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt);
        }

        public UserAuthResponseDTO GetUserFromJwt(string token)
        {
            try
            {
                var userEmail = DecodeToken(token);

                var user = _userRepository.Find(u => u.Email == userEmail).FirstOrDefault();

                UserAuthResponseDTO userdto = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role

                };

                return (userdto);
            }
            catch (Exception)
            {
                throw new Exception("user not found");
            }

        }

        #region PrivateMethods
        private string DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            var userEmail = jwt.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;

            return userEmail;
        }
        private bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using HMACSHA512 hmac = new(PasswordSalt);
            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return ComputedHash.SequenceEqual(PasswordHash);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role )
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Secret:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        #endregion
    }
}
