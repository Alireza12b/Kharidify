using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class SellerServices : ISellerServices
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerServices(ISellerRepository sellerRepository)
        {

            _sellerRepository = sellerRepository;

        }

        public async Task<SellerDto> GetSellerByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _sellerRepository.GetSellerByUserId(userId, cancellationToken);
        }
    }
}
