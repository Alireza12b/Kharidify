using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Users.Contracts;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Endpoints.RazorPages.UI.Areas.Seller.Pages
{
    public class CreateProductModel : PageModel
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;
        private readonly ISellerServices _sellerServices;
        private readonly IShopServices _shopServices;
        private readonly IProductAppServices _productAppServices;

        public CreateProductModel(ICategoryServices categoryServices, IMapper mapper,
            ISellerServices sellerServices, IShopServices shopServices, IProductAppServices productAppServices)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
            _sellerServices = sellerServices;
            _shopServices = shopServices;
            _productAppServices = productAppServices;
        }

        public List<CategoryVM> categories;
        public List<CreateProductVM> products;

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var result = await _categoryServices.GetAll(cancellationToken);
            categories = _mapper.Map<List<CategoryVM>>(result);
        }

        public async Task<IActionResult> OnPostCreate(ProductVM productVM, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {
                //int userId = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));
                int userId = 9;
                var seller = await _sellerServices.GetSellerByUserId(userId, cancellationToken);
                int sellerid = seller.Id;
                var shop = await _shopServices.GetShopBySellerId(sellerid, cancellationToken);
                int shopid = shop.Id;

                var product = new ProductInputDto()
                {
                    ShopId = shopid,
                    Name = productVM.Name,
                    Description = productVM.Description,
                    CategoryId = productVM.CategoryId,
                    TotalQuantity = productVM.TotalQuantity,
                    Price = productVM.Price,
                    IsAuction = productVM.IsAuction,
                    Image = productVM.Image,
                    AuctionTime = productVM.AuctionTime,
                };

                await _productAppServices.Create(product, cancellationToken);
                return RedirectToPage("CreateProduct");
            }
            else
            {
                return RedirectToPage("CreateProduct");
            }
        }
    }
}
