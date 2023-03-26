using System.Text.Json.Serialization;

namespace Products.Domain.Entities
{
    public class Category
    {
        [JsonIgnore]
        public Guid Id { get; set; } 
        public string CategoryName { get; set; }
        public string Reference { get; set; }
        List<Product> Products { get; set; }
    }
}