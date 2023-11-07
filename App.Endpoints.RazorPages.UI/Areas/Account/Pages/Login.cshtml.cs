using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Account.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IMapper _mapper;

        public LoginModel(IUserAppServices userAppServices, IMapper mapper)
        {
            _userAppServices = userAppServices;
            _mapper = mapper;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLogin(LoginVM model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAppServices.Login(_mapper.Map(model, new UserDto()), cancellationToken);
                if (result.Succeeded)
                {
                    return LocalRedirect("~/index");
                }
                ModelState.AddModelError(string.Empty, "ایمیل یا کلمه عبور اشتباه است *");
            }
            return default;
        }
    }
}
