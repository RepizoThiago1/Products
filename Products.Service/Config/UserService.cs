using Microsoft.IdentityModel.Tokens;
using Products.Domain.DTO.User;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
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
        public void ValidateConfirmKey(string key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new InvalidConfirmKeyException("Please insert the right confirmation key");
            }

            User user = _repository.Find(u => u.ConfirmKey == key).FirstOrDefault() ?? throw new UserNotFoundException("User not found");

            if (user.ConfirmKey == key)
            {
                user.IsUserConfirmed = true;
                _repository.SaveChanges();
            }

        }

        public User Register(UserDTO userDTO)
        {

            var userExists = _repository.Find(x => x.Email == userDTO.Email).FirstOrDefault();

            if (userExists != null)
                throw new UserAlreadyExistsException("User already exists");

            if (userDTO.Email == "")
                throw new EmptyEmailException("Field cannot be empty or null");

            if (userDTO.Password == "")
                throw new EmptyPasswordException("Field cannot be empty or null");


            CreatePasswordHash(userDTO.Password, out byte[] PasswordHash, out byte[] PasswordSalt);

            var ConfirmKey = GenerateConfirmKey(6);

            User user = new()
            {
                Email = userDTO.Email,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                ConfirmKey = ConfirmKey,
            };

            _repository.Add(user);

            return user;
        }
        public User UpdateRole(UpdateUserDTO userDTO)
        {
            var user = _repository.Find(u => u.Email == userDTO.Email).FirstOrDefault() ?? throw new UserNotFoundException("User does not exist");

            if (userDTO.Role != null)
            {
                user.Role = userDTO.Role;
                _repository.SaveChanges();
            }
            return user;
        }

        #region Private Methods
        private static void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using HMACSHA512 hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        private string GenerateConfirmKey(int length)
        {
            Random rand = new();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    
        #endregion
    }
}
