using Products.Domain.Entities;
using Products.Domain.Enums;

namespace Products.Domain.DTO
{
    public class PurchaseOrderDTO
    {
       //ARRUMAR O DTO
        public PaymentMethod PaymentMethod { get; set; }
        public List<Product> Products { get; set; }
    }
}
