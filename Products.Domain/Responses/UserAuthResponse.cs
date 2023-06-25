using Products.Domain.Interfaces.Responses;

namespace Products.Domain.Responses
{
    public class UserAuthResponse : IUserAuthResponse
    {
        public UserAuthResponse(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
        public string Token { get; set; }
        public int ExpiresIn { get ; set; }
        public static UserAuthResponse ToResponse(string token, int expiresIn) => new(token, expiresIn);
    }
}
