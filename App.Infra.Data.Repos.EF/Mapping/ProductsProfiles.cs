using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.DTOs;
using App.Domain.Core.Users.Entities;
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
            CreateMap<Customer, CustomerDto>();
            CreateMap<Seller, SellerDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, SellerDto>();
            CreateMap<UserDto, CustomerDto>();

            CreateMap<Product, ProductInputDto>();
            CreateMap<Product, ProductOutputDto>();

            CreateMap<ProductsPrice, ProductPriceInputDto>();
            CreateMap<ProductsPrice, ProductPriceOutputDto>();

            CreateMap<Auction, AuctionInputDto>();
            CreateMap<Auction, AuctionOutputDto>();

            CreateMap<Cart, CartInputDto>();
            CreateMap<Cart, CartOutputDto>();

            CreateMap<Comment, CommentInputDto>();
            CreateMap<Comment, CommentOutputDto>();

            CreateMap<OrderLine, OrderLineInputDto>();
            CreateMap<OrderLine, OrderLineOutputDto>();
            CreateMap<OrderLineInputDto, OrderLine>();
            CreateMap<OrderLineOutputDto, OrderLine>();

            CreateMap<OrderStatus, OrderStatusInputDto>();
            CreateMap<OrderStatus, OrderStatusOutputDto>();

            CreateMap<Image, ImageInputDto>();
            CreateMap<Image, ImageOutputDto>();

            CreateMap<Shop, ShopInputDto>();
            CreateMap<Shop, ShopOutputDto>();

            CreateMap<Category, CategoryOutputDto>();
            CreateMap<City, CityOutputDto>().ReverseMap();
            CreateMap<Province, ProvinceOutputDto>();

            CreateMap<Seller, SellerDto>();
            CreateMap<SellerDto, Seller>();

            

        }
    }
}
