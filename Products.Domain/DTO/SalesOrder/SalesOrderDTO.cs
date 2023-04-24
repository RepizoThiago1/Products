using Products.Domain.DTO.Customer;
using Products.Domain.Enums;

namespace Products.Domain.DTO.PurchaseOrder
{
    public class SalesOrderDTO
    {
        public CustomerOrderRequestDTO Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<SalesOrderProductsDTO> Products { get; set; }
    }
}
