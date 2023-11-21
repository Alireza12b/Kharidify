using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ShopServices : IShopServices
    {
        private readonly IShopRepository _repository;

        public ShopServices(IShopRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            await _repository.Create(shopInputDto, cancellationToken);
        }

        public async Task Update(ShopInputDto shopInputDto, CancellationToken cancellationToken)
        {
            await _repository.Update(shopInputDto, cancellationToken);
        }

        public async Task DeActive(int Id, CancellationToken cancellationToken)
        {
            await _repository.DeActive(Id, cancellationToken);
        }

        public async Task<ShopOutputDto> GetShopBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            return await _repository.GetShopBySellerId(sellerId, cancellationToken);
        }

        public async Task<List<ShopOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<ShopOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(Id, cancellationToken);
        }

        public async Task Active(int Id, CancellationToken cancellationToken)
        {
            await _repository.Active(Id, cancellationToken);
        }
    }
}
