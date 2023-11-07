using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Threading;

namespace App.Endpoints.RazorPages.UI.Areas.Account.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserAppServices _userServices;
        private readonly ICityServices _cityServices;
        private readonly IProvinceServices _provinceServices;
        private readonly IMapper _mapper;

        public RegisterModel(IMapper mapper, IUserAppServices userServices, IProvinceServices provinceServices,
            ICityServices cityServices)
        {
            _userServices = userServices;
            _mapper = mapper;
            _provinceServices = provinceServices;
            _cityServices = cityServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            
        }


        public async Task<IActionResult> OnPostCreate(RegisterVM model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _userServices.Create(_mapper.Map(model, new UserDto()), cancellationToken);

                if (result.Succeeded)
                {
                    return LocalRedirect("~/index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                        return default;
                    }
                }

            }
            return default;
        }
    }
}
