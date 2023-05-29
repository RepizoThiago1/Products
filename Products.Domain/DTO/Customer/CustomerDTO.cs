using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.Customer
{
    public class CustomerDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CustomerCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
