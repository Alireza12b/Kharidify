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
    public class BuyRepository : IBuyRepository
    {
        private readonly KharidifyDbContext _db;
        private readonly IMapper _mapper;

        public BuyRepository(KharidifyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Buy(List<OrderLineInputDto> orderLines, CancellationToken cancellationToken)
        {
            var admin = await _db.Admins.Where(x => x.Id == 3).FirstOrDefaultAsync(cancellationToken);

            if (!_db.ChangeTracker.AutoDetectChangesEnabled)
            {
                _db.ChangeTracker.AutoDetectChangesEnabled = true;
            }

            foreach (var orderlineDto in orderLines)
            {
                var orderline = _mapper.Map<OrderLine>(orderlineDto);
                orderline.IsDeleted = true;
                orderline.IsPaid = true;
                orderline.PayDate = DateTime.Now;

                var product = await _db.Products.Where(x => x.Id == orderline.ProductId).FirstOrDefaultAsync(cancellationToken);
                var productPrice = await _db.ProductsPrices.Where(x => x.ProductId == product.Id).OrderByDescending(x => x.FromDate).LastAsync(cancellationToken);
                var shop = await _db.Shops.Where(x => x.Id == product.ShopId).FirstOrDefaultAsync(cancellationToken);
                var seller = await _db.Sellers.Where(x => x.Id == shop.SellerId).FirstOrDefaultAsync(cancellationToken);

                double? sumPrice = orderline.Quantity * productPrice.Price;

                product.TotalQuantity -= 1;
                shop.Rank += 1;
                double? websiteShare = 0;

                if (shop.Rank <= 5)
                {
                    seller.Wallet += sumPrice - ((sumPrice * 5) / 100);
                    websiteShare += ((sumPrice * 5) / 100);
                }
                else if (shop.Rank >= 5 && shop.Rank <= 10)
                {
                    seller.Wallet += sumPrice - ((sumPrice * 3) / 100);
                    websiteShare += ((sumPrice * 3) / 100);
                }
                else if (shop.Rank >= 10)
                {
                    seller.Wallet += sumPrice - ((sumPrice * 1) / 100);
                    websiteShare += ((sumPrice * 1) / 100);
                }

                admin.Wallet += websiteShare;

                _db.Attach(orderline);
                _db.Attach(product);
                _db.Update(admin);
                _db.Attach(shop);
                _db.Update(seller);
                _db.Entry(orderline).State = EntityState.Modified;
                _db.Entry(product).State = EntityState.Modified;
                _db.Entry(admin).State = EntityState.Modified;
                _db.Entry(shop).State = EntityState.Modified;
                _db.Entry(seller).State = EntityState.Modified;
                await _db.SaveChangesAsync(cancellationToken);
            }


            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
