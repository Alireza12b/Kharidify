using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.EF.Mapping
{
    public class ProductsProfiles : Profile
    {
        public ProductsProfiles()
        {
            CreateMap<Product, ProductInputDto>();
            CreateMap<Product, ProductOutputDto>();
        }
    }
}
