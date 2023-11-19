using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Domain.Core.Users.Entities;
using App.Infra.Data.SqlServer.EF.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly SignInManager<User> _signInManager;

        public UserRepository(KharidifyDbContext db, UserManager<User> userManager, IMapper mapper,
            SignInManager<User> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserName = userDto.Email,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                IsActive = true,
                IsRemoved = false,
            };

            if (userDto.Role == "Customer")
            {
                user.Customer = new Customer
                {
                    CityId = userDto.CityId,
                    AddressDetail = userDto.AddressDetail,
                    PostalCode = userDto.PostalCode,
                };
            }

            if (userDto.Role == "Seller")
            {
                user.Seller = new Seller
                {

                };
            }

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userDto.Role);
            }

            return result;
        }

        public async Task<SignInResult> Login(UserDto userDto, CancellationToken cancellationToken)
        {
            return await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, true, false);
        }

        public async Task<UserDto> GetUser(string email, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _userManager.Users.AsNoTracking().Where(x => x.Email == email).FirstOrDefaultAsync(cancellationToken));
        }

        public async Task<User> GetUserById(int id, CancellationToken cancellationToken)
        {
            return await _userManager.Users.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task Update(UserDto entity, CancellationToken cancellationToken)
        {
            var user = await GetUserById(entity.Id, cancellationToken);
            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;
                user.PhoneNumber = entity.PhoneNumber;
                _db.Update(user);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.AsNoTracking().ToListAsync();
            var result = _mapper.Map<List<UserDto>>(users);

            foreach (var userDto in result)
            {
                var user = await _userManager.Users.AsNoTracking().FirstAsync(x => x.Email == userDto.Email);
                userDto.Roles = await _userManager.GetRolesAsync(user);
            }
            return result;
        }

        public async Task DeActive(int id, CancellationToken cancellationToken)
        {
            var user = await _db.Users.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            user.IsActive = false;
            await _db.SaveChangesAsync();
        }

        public async Task Active(int id, CancellationToken cancellationToken)
        {
            var user = await _db.Users.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            user.IsActive = true;
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var user = await _db.Users.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            user.IsRemoved = true;
            await _db.SaveChangesAsync();
        }
    }
}
