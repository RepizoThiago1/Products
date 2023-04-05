using Products.Domain.DTO;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public User Register(UserDTO userDTO);
    }
}
