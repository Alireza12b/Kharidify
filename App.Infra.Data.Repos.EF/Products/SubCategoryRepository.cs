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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public SubCategoryRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<SubCategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var subCategories = _mapper.Map<List<SubCategoryOutputDto>>(await _db.SubCategories.AsNoTracking().Include(x => x.Products)
                .ToListAsync(cancellationToken));

            return subCategories.ToList();
        }

        public async Task<SubCategoryOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var subCategory = await _db.SubCategories.AsNoTracking().Include(x => x.Products).Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(subCategory, new SubCategoryOutputDto());
        }
    }
}
