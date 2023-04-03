using Products.Domain.Enums;

namespace Products.Domain.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        List<Customer> Customers { get; set; }
        List<Product> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
