using App.Domain.Core.Products.Contracts.AppServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.DipendencyInjections
{
    public static class DI
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
