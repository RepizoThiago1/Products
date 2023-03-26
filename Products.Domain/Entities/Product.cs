using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Products.Domain.Entities
{
    public class Product
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required] 
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public int Quantity { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        public List<Category> Categories { get; set; }
    }
}
