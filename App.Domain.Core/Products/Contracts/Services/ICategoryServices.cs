using App.Domain.Core.Products.DTOs;

namespace App.Domain.Core.Products.Contracts.Services
{
    public interface ICategoryServices
    {
        Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryOutputDto> GetById(int id, CancellationToken cancellationToken);
    }
}