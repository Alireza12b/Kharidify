using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Users.Contracts;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;

        public OrderlineServices(IOrderlineRepository repository, ICustomerRepository customerRepository, ICartRepository cartRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
        }

        public async Task Create(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken)
        {
            await _repository.Create(orderLineInputDto, cancellationToken);
        }

        public async Task Update(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken)
        {
            await _repository.Update(orderLineInputDto, cancellationToken);
        }

        public async Task<CartOutputDto> FindCartByUserId(int userId, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByUserId(userId, cancellationToken);
            return await _cartRepository.GetByCustomerId(customer.Id, cancellationToken); 
        }

        public async Task<List<OrderLineOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<OrderLineOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(Id, cancellationToken);
        }

        public async Task DeleteById(int Id, CancellationToken cancellationToken)
        {
            await _repository.DeleteById(Id, cancellationToken);
        }

        public async Task <List<OrderLineOutputDto>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _repository.GetByUserId(userId, cancellationToken);
        }
    }
}
