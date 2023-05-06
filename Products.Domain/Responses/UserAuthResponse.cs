using Products.Domain.Interfaces.Responses;

namespace Products.Domain.Responses
{
    public class UserAuthResponse : IUserAuthResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get ; set; }
    }
}
