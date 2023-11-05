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
    }
}
