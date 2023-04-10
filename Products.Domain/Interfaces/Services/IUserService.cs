using Products.Domain.DTO.User;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public User Register(UserDTO userDTO);

    }
}
