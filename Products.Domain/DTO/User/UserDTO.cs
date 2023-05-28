using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.User
{
    public class UserDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
