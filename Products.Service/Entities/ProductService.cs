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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductReferencesRepository _referenceRepository;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository, IProductReferencesRepository referenceRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _referenceRepository = referenceRepository;
        }
        public Product AddProduct(ProductDTO productDTO)
        {
            try
            {
                var productCategory = _categoryRepository.Find(c => c.Reference == productDTO.CategoryReference).FirstOrDefault() ?? throw new Exception("Category does not exist");
                var productReferences = _referenceRepository.Find(p => p.SKU == productDTO.SKU).FirstOrDefault();
                var priceCheck = ValidatePrice(productDTO);

                var product = new Product();

                if (priceCheck)
                {
                    product.Name = productDTO.Name;
                    product.SKU = productDTO.SKU;
                    product.Batch = $"BRGR{Batch.Day}{Batch.Month}{Batch.Year}{productDTO.SKU.ToUpper()}"; //GR = good recipt 
                    product.Description = productDTO.Description;
                    product.Price = productDTO.Price;
                    product.IsActive = productDTO.IsActive;
                    product.Quantity = productDTO.Quantity;
                    product.Note = productDTO.Note;
                    product.CategoryId = productCategory.Id;
                    product.ReferenceId = productReferences.Id;
                    _repository.Add(product);
                    return product;
                }
                else
                {
                    throw new Exception("Price is wrong");
                }
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
        private bool ValidatePrice(ProductDTO productDTO)
        {
            var reference = _referenceRepository.Find(r => r.SKU == productDTO.SKU).FirstOrDefault() ?? throw new Exception("Cannot find price reference of the product");

            if (reference.Price != productDTO.Price)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
