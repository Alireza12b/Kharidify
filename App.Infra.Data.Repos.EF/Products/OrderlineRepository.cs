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
    public class OrderlineRepository : IOrderlineRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public OrderlineRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken)
        {
            var orderline = _mapper.Map<OrderLine>(orderLineInputDto);
            await _db.AddAsync(orderline, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken)
        {
            var orderline = await _mapper.ProjectTo<OrderLineInputDto>(_db.Set<OrderLineInputDto>())
                .Where(x => x.Id == orderLineInputDto.Id).FirstOrDefaultAsync();
            _mapper.Map(orderLineInputDto, orderline);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<OrderLineOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var orderlines = _mapper.Map<List<OrderLineOutputDto>>(await _db.OrderLines.AsNoTracking().Include(x => x.Cart)
                .ToListAsync(cancellationToken));

            return orderlines.ToList();
        }

        public async Task<OrderLineOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var orderline = await _db.OrderLines.AsNoTracking().Include(x => x.Cart).Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(orderline, new OrderLineOutputDto());
        }
    }
}
