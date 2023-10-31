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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public ProvinceRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ProvinceOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var provinces = _mapper.Map<List<ProvinceOutputDto>>(await _db.Provinces.AsNoTracking().Include(x => x.Cities)
                .ToListAsync(cancellationToken));

            return provinces.ToList();
        }

        public async Task<ProvinceOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var province = await _db.Provinces.AsNoTracking().Include(x => x.Cities).Where(p => p.Id == Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map(province, new ProvinceOutputDto());
        }
    }
}
