using Products.Domain.DTO.User;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace Products.Service.Config
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
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

        #region Metodos privados
        private void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using HMACSHA512 hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        #endregion
    }
}
