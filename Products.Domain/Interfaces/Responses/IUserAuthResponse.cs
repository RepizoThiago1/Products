using Products.Domain.Responses;

namespace Products.Domain.Interfaces.Responses
{
    public interface IUserAuthResponse
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public static UserAuthResponse ToResponse(string token, int expiresIn) => new(token, expiresIn);
    }
}
