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
    public class AuctionServices : IAuctionServices
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IImageServices _imageServices;

        public AuctionServices(IAuctionRepository auctionRepository, IImageServices imageServices)
        {
            _auctionRepository = auctionRepository;
            _imageServices = imageServices;
        }

        public async Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _auctionRepository.GetAll(cancellationToken);
            foreach (var item in result)
            {
                item.ImagePath = (await _imageServices.GetAll(cancellationToken)).Where(x => x.ProductsId == item.ProductId).FirstOrDefault().Address;
            }
            return result;   
        }


        public async Task<AuctionOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _auctionRepository.GetById(Id, cancellationToken);
            result.ImagePath = (await _imageServices.GetAll(cancellationToken)).Where(x => x.ProductsId == result.ProductId).FirstOrDefault().Address;
            return result;
        }
    }
}
