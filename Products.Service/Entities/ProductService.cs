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
            try
            {
                Product product = new()
                {
                    Name = productDTO.Name,
                    SKU = productDTO.SKU,
                    Batch = $"BRGR{Batch.Day}{Batch.Month}{Batch.Year}{productDTO.SKU.ToUpper()}", //GR = good recipt 
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetById(id);
        }
        #region Private Methods
        private decimal ValidatePrice(decimal price)
        {
            /*
             * @TODO
             *  criar a entity de referencia
             *  linkar a entity com o produto
             */

            /*
             * /var reference = _repository.Find(c => c.Ref == price.Ref) ?? throw new Exception("Cannot find price reference of the product");
             * 
             * 

                if (reference != price)
                    throw new Exception("Price is wrong");

                return price;
             * 
             * 
             */

            return price;
        }
        #endregion
    }
}
