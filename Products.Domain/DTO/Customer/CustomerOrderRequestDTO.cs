using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Products.Domain.DTO.Customer
{
    public class CustomerOrderRequestDTO
    {
        [Required]
        public string CustomerCode { get; set; }
    }
}
