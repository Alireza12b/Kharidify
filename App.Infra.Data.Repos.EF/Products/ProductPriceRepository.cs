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
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public ProductPriceRepository(KharidifyDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }


        public async Task<ProductPriceOutputDto> GetByProductId(int id, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<ProductPriceOutputDto>(await _db.ProductsPrices.AsNoTracking().Where(x => x.ProductId == id).OrderByDescending(x => x.FromDate).LastAsync(cancellationToken));
            return result;
        }
    }
}
