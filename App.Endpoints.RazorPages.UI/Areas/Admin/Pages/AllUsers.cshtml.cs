using App.Domain.AppServices;
using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Admin.Pages
{
    public class AllUsersModel : PageModel
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public List<UserVM> users;

        public AllUsersModel(IUserAppServices userAppServices, IMapper mapper, IUserServices userServices)
        {
            _mapper = mapper;
            _userAppServices = userAppServices;
            _userServices = userServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var results = await _userAppServices.GetAllUsers(cancellationToken);
            users = _mapper.Map<List<UserVM>>(results);
        }

        public async Task<IActionResult> OnPostUpdate(UserVM userVM, CancellationToken cancellationToken)
        {
            var userDto = _mapper.Map<UserDto>(userVM);
            await _userServices.Update(userDto, cancellationToken);
            return RedirectToPage("AllUsers");
        }

        public async Task<IActionResult> OnPostActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _userAppServices.Active(id, cancellationToken);
                return RedirectToPage("AllUsers");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _userAppServices.DeActive(id, cancellationToken);
                return RedirectToPage("AllUsers");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _userAppServices.Delete(id, cancellationToken);
                return RedirectToPage("AllUsers");
            }

            return Page();
        }
    }
}
