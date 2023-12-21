using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Users.Contracts;
using App.Endpoints.RazorPages.UI.ViewModels;
using App.Infra.Data.Repos.EF.Products;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Endpoints.RazorPages.UI.Areas.Seller.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductAppServices _productAppServices;
        private readonly ISellerServices _sellerServices;
        private readonly IShopServices _shopServices;
        private readonly IMapper _mapper;

        public List<ProductVM> products;

        public ProductModel(IProductAppServices productAppServices, IMapper mapper, ISellerServices sellerServices, IShopServices shopServices)
        {
            _mapper = mapper;
            _productAppServices = productAppServices;
            _sellerServices = sellerServices;
            _shopServices = shopServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var seller = _sellerServices.GetSellerByUserId(userId, cancellationToken);
            var shop = _shopServices.GetShopBySellerId(seller.Id, cancellationToken);

            var results = (await _productAppServices.GetAll(cancellationToken)).Where(x => x.ShopId == shop.Id).ToList();
            products = _mapper.Map<List<ProductVM>>(results);
            
        }
    }
}
