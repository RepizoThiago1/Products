namespace Products.Domain.Interfaces.Responses
{
    public interface IUserAuthResponse
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
