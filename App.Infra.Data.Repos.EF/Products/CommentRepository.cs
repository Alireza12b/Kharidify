using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.DTOs;
using App.Infra.Data.SqlServer.EF.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.Products
{
    public class CommentRepository : ICommentRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public CommentRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<CommentOutputDto>>(await _db.Comments.AsNoTracking().Include(x => x.User).Include(y => y.Product).ToListAsync(cancellationToken));
            return result;
        }

        public async Task Deactive(int id, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<CommentInputDto>(await _db.Comments.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken));
            result.isActive = false;
        }

        public async Task Active(int id, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<CommentInputDto>(await _db.Comments.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken));
            result.isActive = true;
        }
    }
}
