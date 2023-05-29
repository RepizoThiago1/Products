using Products.Domain.DTO.User;

namespace Products.Domain.Interfaces.Services
{
    public interface IMailerService
    {
        public void ForgotPassword(string request);
    }
}
