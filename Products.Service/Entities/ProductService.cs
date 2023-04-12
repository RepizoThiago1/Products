using Products.Domain.DTO.Product;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.Workflow
{
    public class ProductService : IProductService
    {
        public DateOnly Batch;
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product AddProduct(ProductDTO productDTO)
        {
            Product product = new()
            {
                Name = productDTO.Name,
                SKU = productDTO.SKU,
                Batch = $"BRGR{Batch.Day}{Batch.Month}{Batch.Year}{productDTO.SKU}", //GR = good recipt 
                Description = productDTO.Description,
                Price = productDTO.Price,
                IsActive = productDTO.IsActive,
                Quantity = productDTO.Quantity,
                Note = productDTO.Note,
                CategoryId = productDTO.CategoryId,
            };

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
