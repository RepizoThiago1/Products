using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Products.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public User Register(UserDTO userDTO)
        {
            User userExists = _repository.Find(x => x.Email == userDTO.Email).FirstOrDefault();

            if (userExists != null)
            {
                throw new Exception("User Already Exists");
            }

            CreatePasswordHash(userDTO.Password, out byte[] PasswordHash, out byte[] PasswordSalt);

            User user = new()
            {
                Email = userDTO.Email,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt
            };

            _repository.Add(user);

            return user;
        }

        public bool VerifyPasswordHash(UserDTO userDTO)
        {
            User user = _repository.Find(x => x.Email == userDTO.Email).FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            return VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt);
        }

        public string CreateToken(UserDTO userDTO)
        {
            var user = _repository.Find(x => x.Email == userDTO.Email).FirstOrDefault();

            if (user == null)
            {
                return string.Empty;
            }

            var token = CreateToken(user);

            return token;
        }
        #region Metodos privados
        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using HMACSHA512 hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using HMACSHA512 hmac = new HMACSHA512(PasswordSalt);
            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return ComputedHash.SequenceEqual(PasswordHash);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email)
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
