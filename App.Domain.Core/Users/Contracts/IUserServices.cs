using App.Domain.Core.Users.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contracts
{
    public interface IUserServices
    {
        Task<IdentityResult> Create(UserDto userDto, CancellationToken cancellationToken);
    }
}
