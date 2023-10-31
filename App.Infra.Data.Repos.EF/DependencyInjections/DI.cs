using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Entities;
using App.Infra.Data.Repos.EF.Products;
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
            services.AddScoped<ISubCategoryRepository ,SubCategoryRepository>();

            return services;
        }
    }
}
