using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Services
{
    public interface ICommentServices
    {
        Task Active(int id, CancellationToken cancellationToken);
        Task Deactive(int id, CancellationToken cancellationToken);
        Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken);
        Task Create(CommentInputDto comment, CancellationToken cancellationToken);
    }
}
