using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Domain.Core.Users.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class UserAppServices : IUserAppServices
    {
        private readonly IUserServices _userServices;
        private readonly ICityRepository _cityRepository;

        public UserAppServices(IUserServices userServices, ICityRepository cityRepository)
        {
            _userServices = userServices;
            _cityRepository = cityRepository;
        }

        public async Task<IdentityResult> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            userDto.CityId = await _cityRepository.GetCityIdByName(userDto.City, cancellationToken);
            return await _userServices.Create(userDto, cancellationToken);
        }

        public async Task DeActive(int id, CancellationToken cancellationToken)
        {
            await _userServices.DeActive(id, cancellationToken);
        }

        public async Task<SignInResult> Login(UserDto userDto, CancellationToken cancellationToken)
        {
            return await _userServices.Login(userDto, cancellationToken);
        }

        public async Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _userServices.GetAllUsers(cancellationToken);
        }

        public async Task Active(int id, CancellationToken cancellationToken)
        {
            await _userServices.Active(id, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _userServices.Delete(id, cancellationToken);
        }

        public async Task<UserDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _userServices.GetById(id, cancellationToken);
        }
    }
}
