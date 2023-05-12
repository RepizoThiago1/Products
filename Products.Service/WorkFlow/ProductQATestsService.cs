using Products.Domain.Entities;
using Products.Domain.DTO.ProductQATests;
using Products.Domain.Exceptions;
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

        public ProductQATests ApproveProduct(ProductQATestsDTO productQATestDTO)
        {
            var reference = GetProductReferencesToTest(productQATestDTO);
            var product = GetProductToTest(productQATestDTO);
            var isSizeAproved = ApproveSize(productQATestDTO);
            var isWeightAproved = ApproveWeight(productQATestDTO);
            var observations = SetObservation(productQATestDTO);
            var isApproved = ApproveTest(productQATestDTO);

            ProductQATests productQATest = new()
            {
                SKU = productQATestDTO.SKU,
                Weight = productQATestDTO.Weight,
                Size = productQATestDTO.Size,
                IsSizeAproved = isSizeAproved,
                IsWeightAproved = isWeightAproved,
                ProductId = product.Id,
                ProductReferencesId = reference.Id,
                Observations = observations,
                Status = isApproved ? "Approved" : "Rejected"
            };

            if (isApproved)
            {
                _repository.Add(productQATest);
                product.ProductQATestsId = productQATest.Id;
                _productService.UpdateProductStatus(product);
                return productQATest;
            }

            throw new QATestNotApprovedException("Product not allowed to be active");
        }

        #region Private Methods
        private string SetObservation(ProductQATestsDTO productQATestsDTO)
        {
            string observations = "";

            if (productQATestsDTO.Observations != null)
            {
                return productQATestsDTO.Observations;
            }

            return observations;
        }
        private bool ApproveTest(ProductQATestsDTO productQATestDTO)
        {
            bool size = ApproveSize(productQATestDTO);
            bool weight = ApproveWeight(productQATestDTO);

            if (size && weight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ApproveSize(ProductQATestsDTO productQATestDTO)
        {
            var sizeReference = _productReferencesRepository.Find(s => s.SKU == productQATestDTO.SKU).FirstOrDefault() ?? throw new ReferenceNotFoundException("There are no references about this product");

            if (productQATestDTO.Size >= sizeReference.MinimumSizeAllowed && productQATestDTO.Size <= sizeReference.MaximumSizeAllowed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool ApproveWeight(ProductQATestsDTO productQATestDTO)
        {
            var weightReferece = _productReferencesRepository.Find(s => s.SKU == productQATestDTO.SKU).FirstOrDefault() ?? throw new ReferenceNotFoundException("There are no references about this product");

            if (productQATestDTO.Weight >= weightReferece.MinimumWeightAllowed && productQATestDTO.Weight <= weightReferece.MaximumWeightAllowed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Product GetProductToTest(ProductQATestsDTO productQATestDTO)
        {
            var product = _productRepository.Find(p => p.SKU == productQATestDTO.SKU).FirstOrDefault(p => p.IsActive == false && p.Batch == productQATestDTO.Batch);

            return product ?? throw new ProductNotFoundException("Product not found");
        }
        private ProductReferences GetProductReferencesToTest(ProductQATestsDTO productQATestDTO)
        {
            var reference = _productReferencesRepository.Find(r => r.SKU == productQATestDTO.SKU).FirstOrDefault();

            return reference ?? throw new ReferenceNotFoundException("Reference not found");
        }
        #endregion
    }
}
