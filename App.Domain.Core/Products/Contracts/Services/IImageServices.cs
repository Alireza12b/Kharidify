using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Services
{
    public interface IImageServices
    {
        Task<List<ImageOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ImageOutputDto> GetById(int id, CancellationToken cancellationToken);

    }
}
