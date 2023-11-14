using App.Domain.Core.Products.DTOs;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface ICommentRepository
    {
        Task Active(int id, CancellationToken cancellationToken);
        Task Deactive(int id, CancellationToken cancellationToken);
        Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken);
    }
}