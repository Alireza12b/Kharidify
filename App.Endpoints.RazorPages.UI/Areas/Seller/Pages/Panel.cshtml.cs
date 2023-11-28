using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Repositories;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Users.Contracts;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Endpoints.RazorPages.UI.Areas.Seller.Pages
{
    public class PanelModel : PageModel
    {
        private readonly IShopServices _shopServices;
        private readonly ISellerServices _sellerServices;
        private readonly IMapper _mapper;

        public PanelModel(IShopServices shopServices, IMapper mapper, ISellerServices sellerServices)
        {
            _mapper = mapper;
            _shopServices = shopServices;
            _sellerServices = sellerServices;
        }

        public ShopVM shop;

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _sellerServices.GetSellerByUserId(userId, cancellationToken);
            shop = _mapper.Map<ShopVM>(await _shopServices.GetShopBySellerId(result.Id ,cancellationToken));
        }
    }
}
