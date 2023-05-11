using Products.Domain.DTO.User;

namespace Products.Domain.Interfaces.Services.Config
{
    public interface IAuthService
    {
        public string CreateToken(UserDTO userDTO);
        public bool VerifyPasswordHash(UserDTO userDTO);
        public UserAuthResponseDTO GetUserFromJwt(string token);
    }
}
