using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.User
{
    public class UserDTO
    {
        public UserDTO()
        {

        }

        public UserDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public static UserDTO FromEntity(string email, string password) => new(email, password);
    }
}
