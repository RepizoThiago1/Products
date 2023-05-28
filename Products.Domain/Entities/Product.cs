using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Batch { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = false;
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        #region Fk's
        public virtual int CategoryId { get; set; }
        [ForeignKey("ProductQATests")]
        public virtual int? ProductQATestsId { get; set; }
        public virtual QATest? ProductQATests { get; set; }
        [ForeignKey("Reference")]
        public virtual int? ReferenceId { get; set; }
        public virtual ProductReferences? Reference { get; set; }
        [ForeignKey("OrderDetails")]
        public virtual int? OrderDetailId { get; set; }
        public virtual OrderDetails? OrderDetails { get; set; }
        #endregion
    }
}
