using App.Domain.Core.Products.Contracts.AppServices;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Admin.Pages
{
    public class ActiveProductsModel : PageModel
    {
        private readonly IProductAppServices _productAppServices;
        private readonly IMapper _mapper;

        public List<ProductVM> products;

        public ActiveProductsModel(IProductAppServices productAppServices, IMapper mapper)
        {
            _mapper = mapper;
            _productAppServices = productAppServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var results = await _productAppServices.GetAllDeActives(cancellationToken);
            products = _mapper.Map<List<ProductVM>>(results);
        }

        public async Task<IActionResult> OnPostActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _productAppServices.Active(id, cancellationToken);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _productAppServices.DeActive(id, cancellationToken);
            }

            return Page();
        }
    }
}
