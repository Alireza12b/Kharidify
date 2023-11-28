using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Services;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IProductAppServices _productAppServices;
        private readonly IMapper _mapper;

        public IndexModel(ICategoryServices categoryServices, IMapper mapper, IProductAppServices productAppServices)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
            _productAppServices = productAppServices;
        }

        public List<CategoryVM> categories { get; set; }

        public List<ProductVM> products { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            categories = _mapper.Map<List<CategoryVM>>(await _categoryServices.GetAll(cancellationToken));
            products = _mapper.Map<List<ProductVM>>(await _productAppServices.GetAll(cancellationToken));
        }
    }
}