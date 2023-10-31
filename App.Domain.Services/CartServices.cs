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
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _repository;

        public CartServices(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CartInputDto cartInputDto, CancellationToken cancellationToken)
        {
            await _repository.Create(cartInputDto, cancellationToken);
        }

        public async Task Update(CartInputDto cartInputDto, CancellationToken cancellationToken)
        {
            await _repository.Update(cartInputDto, cancellationToken);
        }

        public async Task<List<CartOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<CartOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(Id, cancellationToken);
        }
    }
}
