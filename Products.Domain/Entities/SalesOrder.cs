using Products.Domain.Enums;

namespace Products.Domain.Entities
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<OrderDetails> OrdersDetails { get; set; }
    }
}
