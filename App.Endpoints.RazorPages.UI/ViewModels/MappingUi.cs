using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Users.DTOs;
using AutoMapper;

namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class MappingUi : Profile
    {
        public MappingUi()
        {
            CreateMap<UserDto, UserVM>();
            CreateMap<CommentOutputDto, UserVM>();
            CreateMap<CommentInputDto, UserVM>();
            CreateMap<UserVM, UserDto>();
            CreateMap<CustomerVM, CustomerDto>();
            CreateMap<SellerVM, SellerDto > ();
            CreateMap<UserVM, CustomerDto>();
            CreateMap<RegisterVM, UserDto>();
            CreateMap<RegisterVM, CityOutputDto>();
            CreateMap<UserVM, CustomerDto>();
            CreateMap<LoginVM, UserDto>();
            CreateMap<ProductVM, ProductOutputDto>();
            CreateMap<ProductOutputDto, ProductVM>();
            CreateMap<CategoryVM, CategoryOutputDto>();
            CreateMap<CategoryOutputDto, CategoryVM>();
            CreateMap<ProductInputDto, ProductVM>();
            CreateMap<ShopOutputDto, ShopVM>();
            CreateMap<CommentOutputDto, CommentVM>();
            CreateMap<CategoryOutputDto, CategoryVM>();
            CreateMap<CategoryVM, CategoryOutputDto>();
            CreateMap<OrderLineVM, OrderLineInputDto>();
            CreateMap<OrderLineInputDto, OrderLineVM>();
            CreateMap<OrderLineVM, OrderLineOutputDto>();
            CreateMap<OrderLineOutputDto, OrderLineVM>();
        }
    }
}
