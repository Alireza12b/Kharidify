using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface ICartRepository
    {
        Task Create(CartInputDto cartInputDto, CancellationToken cancellationToken);
        Task Update(CartInputDto cartInputDto, CancellationToken cancellationToken);
        Task<List<CartOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<CartOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
