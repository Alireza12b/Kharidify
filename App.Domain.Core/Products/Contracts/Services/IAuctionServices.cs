using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Services
{
    public interface IAuctionServices
    {
        Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<AuctionOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
