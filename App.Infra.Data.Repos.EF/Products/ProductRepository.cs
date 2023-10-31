using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly KharidifyDbContext _db;

        public ProductRepository(KharidifyDbContext db)
        {
            _db = db;          
        }

        public async Task<int> Add(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = productInputDto.Name,
                ShopId = productInputDto.ShopId,
                SubCategoriesId = productInputDto.SubCategoriesId,
                Description = productInputDto.Description,
                TotalQuantity = productInputDto.TotalQuantity,
                IsActive = productInputDto.IsActive,
                SubCategories = productInputDto.SubCategories,
                Shop = productInputDto.Shop,
            };

            await _db.AddAsync(product, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return product.Id;
        }

        public async Task<int> Update(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == productInputDto.Id);

            product.Name = productInputDto.Name;
            product.ShopId = productInputDto.ShopId;
            product.SubCategoriesId = productInputDto.SubCategoriesId;
            product.Description = productInputDto.Description;
            product.TotalQuantity = productInputDto.TotalQuantity;
            product.IsActive = productInputDto.IsActive;

            await _db.SaveChangesAsync(cancellationToken);
            return product.Id;
        }

        public async Task<int> Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(Id);
            product.IsRemoved = true;
            await _db.SaveChangesAsync();
            return product.Id;
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var products = _db.Products.AsNoTracking().Select(product => new ProductOutputDto
            {
                Id = product.Id,
                ShopId = product.ShopId,
                SubCategoriesId = product.SubCategoriesId,
                Name = product.Name,
                Description = product.Description,
                TotalQuantity = product.TotalQuantity,
                IsActive = product.IsActive,
            });

            return products.ToList();
        }

        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == Id);
            var productOutPut = new ProductOutputDto()
            {
                Id = product.Id,
                ShopId = product.ShopId,
                SubCategoriesId = product.SubCategoriesId,
                Name = product.Name,
                Description = product.Description,
                TotalQuantity = product.TotalQuantity,
                IsActive = product.IsActive,
            };

            return productOutPut;
        }
    }
}
