using Products.Domain.DTO.Customer;
using Products.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.PurchaseOrder
{
    public class SalesOrderDTO
    {

        [Required]
        public CustomerOrderRequestDTO Customer { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public List<SalesOrderProductsDTO> Products { get; set; }
    }
}
