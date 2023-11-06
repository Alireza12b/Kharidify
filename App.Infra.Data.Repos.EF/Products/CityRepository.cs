using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.DTOs;
using App.Infra.Data.SqlServer.EF.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.Products
{
    public class CityRepository : ICityRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public CityRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CityOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var cities = _mapper.Map<List<CityOutputDto>>(await _db.Cities.AsNoTracking().Include(x => x.Carts)
                .ToListAsync(cancellationToken));

            return cities.ToList();
        }

        public async Task<CityOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var city = await _db.Cities.AsNoTracking().Include(x => x.Carts).Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(city, new CityOutputDto());
        }

        public async Task<List<CityOutputDto>> GetByProvinceId(int provinceId, CancellationToken cancellationToken)
        {
            var cities = await _db.Cities
            .Where(c => c.ProvinceId == provinceId)
            .ToListAsync(cancellationToken);

            return _mapper.Map<List<CityOutputDto>>(cities);
        }

        public async Task<int> GetCityIdByName(string name, CancellationToken cancellationToken)
        {
            var city = await _db.Cities.AsNoTracking().Include(x => x.Carts).Where(p => p.Name == name).FirstOrDefaultAsync(cancellationToken);

            return city.Id;
        }
    }
}
