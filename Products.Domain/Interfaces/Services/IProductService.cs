using Products.Domain.DTO.Product;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Product AddProduct(ProductDTO product);
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
        public void UpdateProductStatus(Product product);
    }
}
