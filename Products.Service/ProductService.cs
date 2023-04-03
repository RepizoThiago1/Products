using Products.Domain.DTO;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product AddProduct(CreateProductDTO productDTO)
        {
            Product product = new();
            {
                product.Name = productDTO.Name;
                product.Description = productDTO.Description;
                product.Price = productDTO.Price;
                product.IsActive = productDTO.IsActive;
                product.Quantity = productDTO.Quantity;
                product.CategoryId = productDTO.CategoryId;
            }

            _repository.Add(product);

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetById(id);
        }
    }
}
