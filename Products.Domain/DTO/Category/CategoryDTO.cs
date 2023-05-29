using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.Category
{
    public class CategoryDTO
    {
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Reference { get; set; }
    }
}
