using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
