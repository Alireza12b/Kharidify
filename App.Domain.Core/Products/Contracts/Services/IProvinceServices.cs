using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Services
{
    public interface IProvinceServices
    {
        Task<List<ProvinceOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<ProvinceOutputDto> GetById(int Id, CancellationToken cancellationToken);
    }
}
