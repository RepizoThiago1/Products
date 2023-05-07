using Products.Domain.Interfaces.Responses;

namespace Products.Domain.Responses
{
    public class UserAuthResponse : IUserAuthResponse
    {
        public string Token { get; set; }
        public int ExpiresIn { get ; set; }
    }
}
