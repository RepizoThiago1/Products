using Products.Domain.DTO;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Product AddProduct(CreateProductDTO product);
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
    }
}
