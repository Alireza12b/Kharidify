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
        }
    }
}
