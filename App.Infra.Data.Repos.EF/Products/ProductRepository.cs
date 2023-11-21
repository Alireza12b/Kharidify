using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.SqlServer.EF.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Create(ProductInputDto productInputDto, CancellationToken cancellationToken)
        {
            List<ProductsPrice> productsPrices = new List<ProductsPrice>();
            List<Image> images = new List<Image>();

            var product = new Product()
            {
                ShopId = productInputDto.ShopId,
                CategoryId = productInputDto.CategoryId,
                Name = productInputDto.Name,
                Description = productInputDto.Description,
                TotalQuantity = productInputDto.TotalQuantity,
                IsActive = false,
                IsRemoved = false,
            };


            productsPrices.Add(new ProductsPrice()
            {
                Price = productInputDto.Price,
                FromDate = DateTime.Now,
                DiscountPercent = 0,
            });


            images.Add(new Image()
            {
                Address = productInputDto.ImageAddress
            });


            product.ProductsPrices = productsPrices;
            product.Images = images;

            if (productInputDto.IsAuction)
            {
                product.Auctions = new Auction()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(productInputDto.AuctionTime),
                    IsRemoved = false,
                    IsActive = false
                };
            }


            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int Id, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(Id);
            product.IsRemoved = true;
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeActive(int Id, CancellationToken cancellationToken)
        {
            var product = await GetById(Id, cancellationToken);
            product.IsActive = false;
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task Active(int Id, CancellationToken cancellationToken)
        {
            var product = await GetById(Id, cancellationToken);
            product.IsActive = true;
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var products = _mapper.Map<List<ProductOutputDto>>(await _db.Products.AsNoTracking().Include(x => x.Category).Include(y => y.Images).Include(z => z.ProductsPrices)
                .ToListAsync(cancellationToken));

            return products.ToList();
        }

        public async Task<ProductOutputDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var product = await _db.Products.AsNoTracking().Include(x => x.Category).Include(y => y.Images).Include(z => z.ProductsPrices)
                .Where(p => p.Id == Id).FirstOrDefaultAsync();

            return _mapper.Map(product, new ProductOutputDto());
        }
    }
}
