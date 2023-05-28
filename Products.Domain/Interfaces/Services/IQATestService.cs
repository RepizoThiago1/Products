using Products.Domain.DTO.ProductQATests;
using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Services
{
    public interface IQATestService
    {
        public QATest ApproveProduct(QATestDTO productQATestDTO);
    }
}
