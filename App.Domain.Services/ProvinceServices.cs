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
    public class ProvinceServices : IProvinceServices
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceServices(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<List<ProvinceOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _provinceRepository.GetAll(cancellationToken);
        }

        public async Task<ProvinceOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _provinceRepository.GetById(Id, cancellationToken);
        }
    }
}
