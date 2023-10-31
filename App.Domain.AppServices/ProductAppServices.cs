using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class ProductAppServices : IProductAppServices
    {
        private readonly IProductServices _productService;

        public ProductAppServices(IProductServices productService)
        {
            _productService = productService;
        }

        public async Task Create(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            await _productService.Create(productInputDto, cancellationToken);
        }

        public async Task Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _productService.GetById(productInputDto.Id, cancellationToken);
            if (product != null)
            {
                await _productService.Update(productInputDto, cancellationToken);
            }
        }

        public async Task Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetById(Id, cancellationToken);
            if (product != null)
            {
                await _productService.Delete(Id, cancellationToken);
            }
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _productService.GetAll(cancellationToken);
        }

        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _productService.GetById(Id, cancellationToken);
        }
    }
}
