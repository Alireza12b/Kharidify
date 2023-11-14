using App.Domain.Core.Products.DTOs;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface IImageRepository
    {
        Task<ImageOutputDto> GetAll(CancellationToken cancellationToken);
        Task<ImageOutputDto> GetById(int id, CancellationToken cancellationToken);
    }
}