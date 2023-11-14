using App.Domain.Core.Products.DTOs;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface IProductPriceRepository
    {
        Task<ProductPriceOutputDto> GetByProductId(int id, CancellationToken cancellationToken);
    }
}