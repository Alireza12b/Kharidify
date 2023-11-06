using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Contracts.Repositories
{
    public interface ICityRepository
    {
        Task<List<CityOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<CityOutputDto> GetById(int Id, CancellationToken cancellationToken);
        Task<List<CityOutputDto>> GetByProvinceId(int provinceId, CancellationToken cancellationToken);
        Task<int> GetCityIdByName(string name, CancellationToken cancellationToken);
    }
}
