using Products.Domain.Enums;

namespace Products.Domain.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
