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
    public class AuctionRepository : IAuctionRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public AuctionRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        {
            var auction = _mapper.Map<Auction>(auctionInputDto);
            await _db.AddAsync(auction, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(AuctionInputDto auctionInputDto, CancellationToken cancellationToken)
        {
            var auction = await _mapper.ProjectTo<AuctionInputDto>(_db.Set<AuctionInputDto>())
                .Where(x => x.Id == auctionInputDto.Id).FirstOrDefaultAsync();
            _mapper.Map(auctionInputDto, auction);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeActive(int Id, CancellationToken cancellationToken)
        {
            var auction = await _db.Auctions.FindAsync(Id);
            auction.IsActive = false;
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var auctions = _mapper.Map<List<AuctionOutputDto>>(await _db.Auctions.AsNoTracking()
                .ToListAsync(cancellationToken));

            return auctions.ToList();
        }

        public async Task<AuctionOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var auction = await _db.Auctions.AsNoTracking().Where(p => p.Id == Id).FirstOrDefaultAsync();

            return _mapper.Map(auction, new AuctionOutputDto());
        }
    }
}
