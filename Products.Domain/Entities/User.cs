using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "Default";
        public string ConfirmKey { get; set; }
        public bool IsUserConfirmed { get; set; } = false;
    }
}
