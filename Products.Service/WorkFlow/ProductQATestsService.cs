using Products.Domain.DTO.ProductQATests;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Services;

namespace Products.Service.WorkFlow
{
    public class ProductQATestsService : IProductQATestsService
    {
        private readonly IProductQATestsRepository _repository;
        private readonly IProductReferencesRepository _productReferencesRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductQATestsService(IProductQATestsRepository repository, IProductReferencesRepository productReferencesRepository, IProductService productService, IProductRepository productRepository)
        {
            _repository = repository;
            _productReferencesRepository = productReferencesRepository;
            _productRepository = productRepository;
            _productService = productService;
        }

        public ProductQATests AproveProduct(ProductQATestsDTO productQATestDTO)
        {
            var isActive = AproveTest(productQATestDTO);
            var isSizeAproved = CheckSize(productQATestDTO);
            var isWeightAproved = CheckWeight(productQATestDTO);
            var product = GetProductToTest(productQATestDTO);
            var reference = GetProductReferencesToTest(productQATestDTO);


            ProductQATests productQATest = new()
            {
                SKU = productQATestDTO.SKU,
                Weight = productQATestDTO.Weight,
                Size = productQATestDTO.Size,
                IsSizeAproved = isSizeAproved,
                IsWeightAproved = isWeightAproved,
                ProductId = product.Id,
                ProductReferencesId = reference.Id
            };

            if (isActive)
            {
                _repository.Add(productQATest);
                product.ProductQATestsId = productQATest.Id;
                _productService.UpdateProductStatus(product);
                return productQATest;
            }

            throw new Exception("Product not allowed to be active");
        }

        #region Private Methods
        private bool AproveTest(ProductQATestsDTO productQATestDTO)
        {
            bool size = CheckSize(productQATestDTO);
            bool weight = CheckWeight(productQATestDTO);

            if (!size && !weight)
            {
                return false;
            }
            return true;
        }
        private bool CheckSize(ProductQATestsDTO productQATestDTO)
        {
            var sizeReference = _productReferencesRepository.Find(s => s.SKU == productQATestDTO.SKU).FirstOrDefault() ?? throw new Exception("There are no references about this product");

            if (sizeReference.Size == productQATestDTO.Size)
            {
                return true;
            }

            if (sizeReference.MinimumSizeAllowed <= productQATestDTO.Size)
            {
                return true;
            }

            if (sizeReference.MaximumSizeAllowed >= productQATestDTO.Size)
            {
                return true;
            }
            return false;
        }
        private bool CheckWeight(ProductQATestsDTO productQATestDTO)
        {
            var weightReferece = _productReferencesRepository.Find(s => s.SKU == productQATestDTO.SKU).FirstOrDefault() ?? throw new Exception("There are no references about this product");

            if (weightReferece.Weight == productQATestDTO.Size)
            {
                return true;
            }

            if (weightReferece.MinimumWeightAllowed <= productQATestDTO.Weight)
            {
                return true;
            }

            if (weightReferece.MaximumWeightAllowed >= productQATestDTO.Weight)
            {
                return true;
            }

            return false;
        }
        private Product GetProductToTest(ProductQATestsDTO productQATestDTO)
        {
            var product = _productRepository.Find(p => p.SKU == productQATestDTO.SKU).FirstOrDefault(p => p.IsActive == false && p.Batch == productQATestDTO.Batch);

            return product ?? throw new Exception("Cannot find product or the batch is wrong");
        }
        private ProductReferences GetProductReferencesToTest(ProductQATestsDTO productQATestDTO)
        {
            var reference = _productReferencesRepository.Find(r => r.SKU == productQATestDTO.SKU).FirstOrDefault();

            return reference ?? throw new Exception("Reference not found");
        }
        #endregion
    }
}
