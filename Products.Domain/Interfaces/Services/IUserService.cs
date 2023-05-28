using Products.Domain.DTO.User;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public void ValidateConfirmKey(string key);
        public User Register(UserDTO userDTO);
        public User UpdateRole(UpdateUserDTO userDTO);

    }
}
