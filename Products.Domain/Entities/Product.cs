using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Batch { get; set; }
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
        public List<PurchaseOrder>? Orders { get; set; }
        public string Note { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
