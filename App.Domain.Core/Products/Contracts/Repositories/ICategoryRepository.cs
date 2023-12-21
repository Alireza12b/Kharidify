using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetById(int Id, CancellationToken cancellationToken);
    }
}
