using Products.Domain.DTO;

namespace Products.Domain.Interfaces.Services.Config
{
    public interface IAuthService
    {
        public string CreateToken(UserDTO userDTO);
        public bool VerifyPasswordHash(UserDTO userDTO);

    }
}
