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
            var categories = _mapper.Map<List<CategoryOutputDto>>(await _db.Categories.AsNoTracking()
                .ToListAsync(cancellationToken));

            return categories.ToList();
        }

        public async Task<List<ProductOutputDto>> GetById(int Id, CancellationToken cancellationToken)
        {
            var product = await _db.Products.AsNoTracking().Where(p => p.CategoryId == Id).ToListAsync(cancellationToken);

            return _mapper.Map(product, new List<ProductOutputDto>());
        }
    }
}
