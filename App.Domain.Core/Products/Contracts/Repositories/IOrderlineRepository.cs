using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface IOrderlineRepository
    {
        Task Create(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken);
        Task Update(OrderLineInputDto orderLineInputDto, CancellationToken cancellationToken);
        Task<List<OrderLineOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<OrderLineOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
