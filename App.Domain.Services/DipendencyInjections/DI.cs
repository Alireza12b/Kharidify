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
            return services;
        }
    }
}
