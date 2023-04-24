using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool IsActive { get; set; } = false;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        #region Fk's
        public virtual int CategoryId { get; set; }
        [ForeignKey("ProductQATests")]
        public virtual int? ProductQATestsId { get; set; }
        public virtual ProductQATests? ProductQATests { get; set; }
        [ForeignKey("Reference")]
        public virtual int? ReferenceId { get; set; }
        public virtual ProductReferences? Reference { get; set; }
        [ForeignKey("OrderDetails")]
        public virtual int? OrderDetailId { get; set; }
        public virtual OrderDetails? OrderDetails { get; set; }
        #endregion
    }
}
