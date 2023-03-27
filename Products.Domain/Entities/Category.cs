using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [StringLength(4, ErrorMessage = "Please insert a 4 character reference for the product!")]
        public string Reference { get; set; }
        public List<Product> Products { get; set; }
    }
}