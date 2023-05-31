using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.WorkFlow
{
    public class MailerService : IMailerService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public MailerService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public void ForgotPassword(string request)
        {
            var user = _userRepository.Find(u => u.Email == request).FirstOrDefault() ?? throw new UserNotFoundException("User not found");

            if (user != null)
            {
                string subject = "Forgot your password";

                string body = $"<h1>Hello dear {user.Email} </h1> " +
                              $"we've notice that you're trying to access our services but forgot your password click here https://localhost:44301/ to reset your password!";

                string emailTo = user.Email;

                SendEmail(body, subject, emailTo);
            }
        }

        #region Private Methods
        private void SendEmail(string body, string subject, string emailTo)
        {
            var mailerOptions = _configuration.GetSection("MailerOptions");

            var emailHost = mailerOptions.GetSection("EmailHost").Value;

            var emailUser = mailerOptions.GetSection("EmailUser").Value;

            var emailPassword = mailerOptions.GetSection("EmailPassword").Value;

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(emailUser));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            var smtp = new SmtpClient();

            smtp.Connect(emailHost, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailUser, emailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        #endregion
    }
}
