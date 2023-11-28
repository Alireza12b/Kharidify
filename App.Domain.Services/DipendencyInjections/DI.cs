using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Users.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.DipendencyInjections
{
    public static class DI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IProvinceServices, ProvinceServices>();
            services.AddScoped<ICityServices, CityServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICommentServices, CommentServices>();
            services.AddScoped<IShopServices, ShopServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<ISellerServices, SellerServices>();
            services.AddScoped<IImageServices, ImageServices>();
            services.AddScoped<IOrderlineServices, OrderlineServices>();

            return services;
        }
    }
}
