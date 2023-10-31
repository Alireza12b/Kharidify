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
    public class CartAppServices : ICartAppServices
    {
        private readonly ICartServices _cartService;

        public CartAppServices(ICartServices cartService)
        {
            _cartService = cartService;
        }

        public async Task Create(CartInputDto cartInputDto, CancellationToken cancellationToken)
        {
            await _cartService.Create(cartInputDto, cancellationToken);
        }

        public async Task Update(CartInputDto cartInputDto, CancellationToken cancellationToken)
        {
            await _cartService.Update(cartInputDto, cancellationToken) ;
        }

        public async Task<List<CartOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _cartService.GetAll(cancellationToken);
        }

        public async Task<CartOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _cartService.GetById(Id, cancellationToken);
        }
    }
}
