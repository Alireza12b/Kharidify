using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _cityRepository;

        public CityServices(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityOutputDto>> GetByProvinceId(int provinceId, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetByProvinceId(provinceId, cancellationToken);
        }
    }
}
