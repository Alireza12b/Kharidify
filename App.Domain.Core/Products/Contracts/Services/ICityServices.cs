using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Services
{
    public interface ICityServices
    {
        Task<List<CityOutputDto>> GetByProvinceId(int provinceId, CancellationToken cancellationToken);
    }
}
