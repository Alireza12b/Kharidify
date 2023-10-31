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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var categories = _mapper.Map<List<CategoryOutputDto>>(await _db.Categories.AsNoTracking().Include(x => x.SubCategories)
                .ToListAsync(cancellationToken));

            return categories.ToList();
        }

        public async Task<CategoryOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.AsNoTracking().Include(x => x.SubCategories).Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(category, new CategoryOutputDto());
        }
    }
}
