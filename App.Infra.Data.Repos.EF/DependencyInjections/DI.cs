using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Contracts;
using App.Infra.Data.Repos.EF.Products;
using App.Infra.Data.Repos.EF.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.DependencyInjections
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICartRepository ,CartRepository>();
            services.AddScoped<ICategoryRepository ,CategoryRepository>();
            services.AddScoped<ICityRepository ,CityRepository>();
            services.AddScoped<IOrderlineRepository ,OrderlineRepository>();
            services.AddScoped<IProductRepository ,ProductRepository>();
            services.AddScoped<IProvinceRepository ,ProvinceRepository>();
            services.AddScoped<IShopRepository ,ShopRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBuyRepository, BuyRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();

            return services;
        }
    }
}
