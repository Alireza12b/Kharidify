using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            
            return await _userRepository.Create(userDto, cancellationToken);
        }

        public async Task DeActive(int id, CancellationToken cancellationToken)
        {
            await _userRepository.DeActive(id, cancellationToken);
        }

        public async Task<SignInResult> Login(UserDto userDto, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUser(userDto.Email, cancellationToken);
            userDto.IsActive = existingUser.IsActive;

            if (userDto.IsActive)
                return await _userRepository.Login(userDto, cancellationToken);

            return default;
        }

        public async Task Update(UserDto entity, CancellationToken cancellationToken)
        {
            await _userRepository.Update(entity, cancellationToken);
        }

        public async Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsers(cancellationToken);
        }

        public async Task Active(int id, CancellationToken cancellationToken)
        {
            await _userRepository.Active(id, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(id, cancellationToken);
        }
    }
}
