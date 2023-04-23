using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CustomerCode { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; } = true;
        public List<SalesOrder> PurchaseOrders { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
