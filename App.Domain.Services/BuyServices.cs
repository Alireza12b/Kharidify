using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class BuyServices : IBuyServices
    {
        private readonly IBuyRepository _buyRepository;

        public BuyServices(IBuyRepository buyRepository)
        {
            _buyRepository = buyRepository;
        }

        public async Task Buy(List<OrderLineInputDto> orderLines, CancellationToken cancellationToken)
        {
            await _buyRepository.Buy(orderLines, cancellationToken);
        }
    }
}
