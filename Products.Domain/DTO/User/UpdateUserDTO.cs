using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.User
{
    public class UpdateUserDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
