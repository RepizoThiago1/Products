using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.Product
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string CategoryReference { get; set; }

        [Required]
        public string Note { get; set; }
    }
}
