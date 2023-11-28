using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class CommentServices : ICommentServices
    {
        private readonly ICommentRepository _commentRepository;

        public CommentServices(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Active(int id, CancellationToken cancellationToken)
        {
             await _commentRepository.Active(id, cancellationToken);
        }

        public async Task Create(CommentInputDto comment, CancellationToken cancellationToken)
        {
            await _commentRepository.Create(comment, cancellationToken);
        }

        public async Task Deactive(int id, CancellationToken cancellationToken)
        {
            await _commentRepository.Deactive(id, cancellationToken);
        }

        public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAll(cancellationToken);
        }
    }
}
