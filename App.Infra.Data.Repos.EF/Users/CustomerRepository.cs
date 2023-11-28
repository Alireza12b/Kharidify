using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Infra.Data.SqlServer.EF.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.Users
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public CustomerRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CustomerDto> GetCustomerByUserId(int userId, CancellationToken cancellationToken)
        {
            return _mapper.Map<CustomerDto>(await _db.Customers.AsNoTracking().Where(x => x.UserId == userId).FirstOrDefaultAsync());
        }
    }
}
