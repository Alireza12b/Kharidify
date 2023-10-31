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

        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            await _repository.Create(productInputDto, cancellationToken);
        }

        public async Task Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(productInputDto.Id, cancellationToken);
            if (product != null)
            {
                await _repository.Update(productInputDto, cancellationToken);
            }
        }

        public async Task Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(Id, cancellationToken);
            if (product != null)
            {
                await _repository.Delete(Id, cancellationToken);
            }
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(Id, cancellationToken);
        }
    }
}
