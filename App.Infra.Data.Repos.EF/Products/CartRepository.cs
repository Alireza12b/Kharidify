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
    public class CartRepository : ICartRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public CartRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(CartInputDto cartInputDto, CancellationToken cancellationToken)
        {
            var cart = _mapper.Map<Cart>(cartInputDto);
            await _db.AddAsync(cart, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(CartInputDto cartInputDto, CancellationToken cancellationToken)
        {
            var cart = await _mapper.ProjectTo<CartInputDto>(_db.Set<CartInputDto>())
                .Where(x => x.Id == cartInputDto.Id).FirstOrDefaultAsync();
            _mapper.Map(cartInputDto, cart);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CartOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var carts = _mapper.Map<List<CartOutputDto>>(await _db.Carts.AsNoTracking().Include(x => x.OrderLines)
                .ToListAsync(cancellationToken));

            return carts.ToList();
        }

        public async Task<CartOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var cart = await _db.Carts.AsNoTracking().Include(x => x.OrderLines).Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(cart, new CartOutputDto());
        }

        public async Task<CartOutputDto> GetByCustomerId(int Id, CancellationToken cancellationToken)
        {
            var cart = await _db.Carts.AsNoTracking().Include(x => x.OrderLines).Where(p => p.CustomerId == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(cart, new CartOutputDto());
        }
    }
}
