using App.Domain.Core.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Contracts
{
    public interface ISellerRepository
    {
        Task<SellerDto> GetSellerByUserId(int userId, CancellationToken cancellationToken);
    }
}
