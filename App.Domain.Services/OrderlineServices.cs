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
    public class OrderlineServices : IOrderlineServices
    {
        private readonly IOrderlineRepository _repository;

        public OrderlineServices(IOrderlineRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken)
        {
            await _repository.Create(orderLineInputDto, cancellationToken);
        }

        public async Task Update(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken)
        {
            await _repository.Update(orderLineInputDto, cancellationToken);
        }

        public async Task<List<OrderLineOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<OrderLineOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(Id, cancellationToken);
        }
    }
}
