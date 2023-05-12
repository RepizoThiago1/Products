using Products.Domain.DTO.ProductQATests;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IProductQATestsService
    {
        public ProductQATests ApproveProduct(ProductQATestsDTO productQATestDTO);
    }
}
