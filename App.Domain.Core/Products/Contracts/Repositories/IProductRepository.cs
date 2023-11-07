using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task Create(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task Update(ProductInputDto productInputDto, CancellationToken cancellationToken);
        Task Delete(int Id, CancellationToken cancellationToken);
        Task DeActive(int Id, CancellationToken cancellationToken);
        Task Active(int Id, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
