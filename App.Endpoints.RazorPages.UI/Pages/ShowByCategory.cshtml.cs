using App.Domain.Core.Products.Contracts.Services;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Pages
{
    public class ShowByCategoryModel : PageModel
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ShowByCategoryModel(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public List<ProductVM> Products { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            var result = (await _productServices.GetAll(cancellationToken)).Where(x => x.CategoryId == id).ToList();
            Products = _mapper.Map<List<ProductVM>>(result);
        }
    }
}
