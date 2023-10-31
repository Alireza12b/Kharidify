using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class ShopAppServices : IShopAppServices
    {
        private readonly IShopServices _shopService;

        public ShopAppServices(IShopServices shopService)
        {
            _shopService = shopService;
        }

        public async Task Create(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            await _shopService.Create(shopInputDto, cancellationToken);
        }

        public async Task Update(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            await _shopService.Update(shopInputDto, cancellationToken);
        }

        public async Task DeActive(int Id, CancellationToken cancellationToken)
        {
            await _shopService.DeActive(Id, cancellationToken);
        }

        public async Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _shopService.GetAll(cancellationToken);
        }

        public async Task<ShopOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _shopService.GetById(Id, cancellationToken);
        }
    }
}
