using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Domain.Core.Users.Entities;
using App.Infra.Data.SqlServer.EF.Migrations;
using App.Infra.Data.SqlServer.EF.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Infra.Data.Repos.EF.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly KharidifyDbContext _db;
        private readonly UserManager<User> _userManager;

        public UserRepository(KharidifyDbContext db, UserManager<User> userManager, IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = new User();

            if (userDto.Role == "Customer")
            {
                user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    UserName = userDto.Email,
                    Email = userDto.Email,
                    PhoneNumber = userDto.Phone,
                    Customer = new Customer()
                };
            }
            
            if (userDto.Role == "Seller")
            {
                user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    UserName = userDto.Email,
                    Email = userDto.Email,
                    PhoneNumber = userDto.Phone,
                    Seller = new Seller()
                    {
                        Shop = new Shop()
                    }
                };
            }

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userDto.Role);
            }
            return result;
        }
    }
}
