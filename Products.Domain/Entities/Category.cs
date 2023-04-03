using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Products.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [StringLength(4, ErrorMessage = "Please insert a 4 character reference for the product!")]
        public string Reference { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}