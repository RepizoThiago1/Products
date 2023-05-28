using Products.Domain.DTO.Reference;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Repository;

namespace Products.Service.Entities
{
    public class ProductReferencesService : IProductReferencesService
    {
        private readonly IProductReferencesRepository _repository;
        private readonly IProductRepository _productRepository;
        public ProductReferencesService(IProductReferencesRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }
        public ProductReferences AddReference(ProductReferencesDTO referenceDTO)
        {
            var referenceCheck = _repository.Find(r => r.SKU == referenceDTO.SKU).FirstOrDefault();

            if (referenceCheck != null)
            {
                throw new ReferenceExistisException("Reference already exists");
            }

            ProductReferences reference = new()
            {
                SKU = referenceDTO.SKU,
                Price = referenceDTO.Price,
                Weight = referenceDTO.Weight,
                Size = referenceDTO.Size,
                MaterialType = referenceDTO.MaterialType,
                MaximumWeightAllowed = referenceDTO.MaximumWeightAllowed,
                MinimumWeightAllowed = referenceDTO.MinimumWeightAllowed,
                MaximumSizeAllowed = referenceDTO.MaximumSizeAllowed,
                MinimumSizeAllowed = referenceDTO.MinimumSizeAllowed,
            };

            _repository.Add(reference);
            return reference;
        }
    }
}
