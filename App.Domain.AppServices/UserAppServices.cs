using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
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

        public async Task DeActive(int id)
        {
            await _userServices.DeActive(id);
        }

        public async Task<SignInResult> Login(UserDto userDto, CancellationToken cancellationToken)
        {
            return await _userServices.Login(userDto, cancellationToken);
        }
    }
}
