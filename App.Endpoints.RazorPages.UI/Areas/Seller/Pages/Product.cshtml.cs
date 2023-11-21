using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Repositories;
using App.Endpoints.RazorPages.UI.ViewModels;
using App.Infra.Data.Repos.EF.Products;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Seller.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductAppServices _productAppServices;
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IMapper _mapper;

        public List<ProductVM> products;

        public ProductModel(IProductAppServices productAppServices, IMapper mapper, IProductPriceRepository productPriceRepository)
        {
            _mapper = mapper;
            _productAppServices = productAppServices;
            _productPriceRepository = productPriceRepository;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var results = await _productAppServices.GetAllDeActives(cancellationToken);
            products = _mapper.Map<List<ProductVM>>(results);
            
        }
    }
}
