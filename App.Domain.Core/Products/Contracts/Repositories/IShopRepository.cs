using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface IShopRepository
    {
        Task Create(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task Update(ShopInputDto shopInputDto, CancellationToken cancellationToken);
        Task DeActive(int Id, CancellationToken cancellationToken);
        Task<ShopOutputDto> GetShopBySellerId(int sellerId, CancellationToken cancellationToken);
        Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ShopOutputDto> GetById(int Id, CancellationToken cancellationToken);
        Task Active(int Id, CancellationToken cancellationToken);
    }
}
