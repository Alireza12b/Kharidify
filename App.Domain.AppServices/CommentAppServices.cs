using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class CommentAppServices : ICommentAppServices
    {
        private readonly ICommentServices _commentServices;

        public CommentAppServices(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        public async Task Active(int id, CancellationToken cancellationToken)
        {
            await _commentServices.Active(id, cancellationToken);
        }

        public async Task Deactive(int id, CancellationToken cancellationToken)
        {
            await _commentServices.Deactive(id, cancellationToken);
        }

        public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _commentServices.GetAll(cancellationToken);
        }
    }
}
