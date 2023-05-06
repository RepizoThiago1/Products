using Products.Domain.Interfaces.Responses.@base;
using Products.Domain.Responses;

namespace Products.Domain.Interfaces.Responses
{
    public interface IUserAuthResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
