using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
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
    public class ShopRepository : IShopRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public ShopRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            var shop = _mapper.Map<Shop>(shopInputDto);
            await _db.AddAsync(shop, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            var shop = await _mapper.ProjectTo<ShopInputDto>(_db.Set<ShopInputDto>())
                .Where(x => x.Id == shopInputDto.Id).FirstOrDefaultAsync();
            _mapper.Map(shopInputDto, shop);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeActive(int Id, CancellationToken cancellationToken)
        {
            var shop = await _db.Shops.FindAsync(Id);
            shop.IsActive = false;
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var shops = _mapper.Map<List<ShopOutputDto>>(await _db.Shops.AsNoTracking().Include(x => x.Products)
                .ToListAsync(cancellationToken));

            return shops.ToList();
        }

        public async Task<ShopOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var shop = await _db.Shops.AsNoTracking().Include(x => x.Products).Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(shop, new ShopOutputDto());
        }
    }
}
