using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class ActiveShopsModel : PageModel
    {
        private readonly IShopAppServices _shopAppServices;
        private readonly IMapper _mapper;

        public List<ShopVM> shops;

        public ActiveShopsModel(IShopAppServices shopAppServices, IMapper mapper)
        {
            _mapper = mapper;
            _shopAppServices = shopAppServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var results = await _shopAppServices.GetAll(cancellationToken);
            shops = _mapper.Map<List<ShopVM>>(results);
        }

        public async Task<IActionResult> OnPostUpdate(ShopVM shopVM, CancellationToken cancellationToken)
        {
            var shopDto = _mapper.Map<ShopInputDto>(shopVM);
            await _shopAppServices.Update(shopDto, cancellationToken);
            return RedirectToPage("ActiveShops");
        }

        public async Task<IActionResult> OnPostActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _shopAppServices.Active(id, cancellationToken);
                return RedirectToPage("ActiveShops");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _shopAppServices.DeActive(id, cancellationToken);
                return RedirectToPage("ActiveShops");
            }

            return Page();
        }

    }
}
