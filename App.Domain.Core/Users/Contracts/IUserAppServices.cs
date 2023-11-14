using App.Domain.Core.Users.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contracts
{
    public interface IUserAppServices
    {
        Task<IdentityResult> Create(UserDto userDto, CancellationToken cancellationToken);
        Task<SignInResult> Login(UserDto userDto, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken);
        Task DeActive(int id, CancellationToken cancellationToken);
        Task Active(int id, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);


    }
}
