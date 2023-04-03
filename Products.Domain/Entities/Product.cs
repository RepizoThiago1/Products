using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required] 
        public decimal Price { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
