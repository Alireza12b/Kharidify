using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface IAuctionRepository
    {
        Task Create(AuctionInputDto auctionInputDto, CancellationToken cancellationToken);
        Task Update(AuctionInputDto auctionInputDto, CancellationToken cancellationToken);
        Task DeActive(int Id, CancellationToken cancellationToken);
        Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<AuctionOutputDto> GetById(int Id, CancellationToken cancellationToken);

    }
}
