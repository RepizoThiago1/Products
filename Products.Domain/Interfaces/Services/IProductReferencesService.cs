using Products.Domain.DTO.Reference;
using Products.Domain.Entities;

namespace Products.Service.Entities
{
    public interface IProductReferencesService
    {
        public ProductReferences AddReference(ProductReferencesDTO referenceDTO);
    }
}
