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
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;
        private readonly IProductPriceRepository _priceRepository;
        private readonly IImageRepository _imageRepository;

        public ProductServices(IProductRepository repository, IImageRepository imageRepository, IProductPriceRepository priceRepository)
        {
            _repository = repository;
            _imageRepository = imageRepository;
            _priceRepository = priceRepository;
        }

        public async Task Create(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            await _repository.Create(productInputDto, cancellationToken);
        }

        public async Task Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(Id, cancellationToken);
            if (product != null)
            {
                await _repository.Delete(Id, cancellationToken);
            }
        }
        public async Task DeActive(int Id, CancellationToken cancellationToken)
        {
            await _repository.DeActive(Id, cancellationToken);
        }

        public async Task Active(int Id, CancellationToken cancellationToken)
        {
            await _repository.Active(Id, cancellationToken);
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var product = await _repository.GetAll(cancellationToken);
            var images = await _imageRepository.GetAll(cancellationToken);

            foreach (var item in product)
            {
                item.LastImageAddress = images.Where(x => x.ProductsId == item.Id).Last().Address;
                item.LastPrice = (await _priceRepository.GetByProductId(item.Id, cancellationToken)).Price;
            }

            return product;
        }

        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(Id, cancellationToken);
            var images = await _imageRepository.GetAll(cancellationToken);

            product.LastImageAddress = images.Where(x => x.ProductsId == product.Id).Last().Address;
            product.LastPrice = (await _priceRepository.GetByProductId(product.Id, cancellationToken)).Price;

            return product;
        }
    }
}
