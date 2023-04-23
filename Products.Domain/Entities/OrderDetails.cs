using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? OrderNumber { get; set; }
        public Product? Product { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        [ForeignKey("PurchaseOrder")]
        public int? PurchaseOrderId { get; set; }
    }
}
