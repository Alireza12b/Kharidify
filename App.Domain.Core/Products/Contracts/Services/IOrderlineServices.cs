using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Services
{
    public interface IOrderlineServices
    {
        Task Create(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken);
        Task Update(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken);
        Task<List<OrderLineOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderLineOutputDto> GetById(int Id, CancellationToken cancellationToken);
        Task<CartOutputDto> FindCartByUserId(int userId, CancellationToken cancellationToken);
    }
}
