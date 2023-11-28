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
    public class ImageRepository : IImageRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public ImageRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ImageOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var results = _mapper.Map<List<ImageOutputDto>>(await _db.Images.AsNoTracking().ToListAsync(cancellationToken));
            return results;
        }

        public async Task<ImageOutputDto> GetById(int id, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<ImageOutputDto>(await _db.Images.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken));
            return result;
        }
    }
}
