using App.Domain.AppServices;
using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Users.Contracts;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Admin.Pages
{
    public class AllUsersModel : PageModel
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IMapper _mapper;

        public List<UserVM> users;

        public AllUsersModel(IUserAppServices userAppServices, IMapper mapper)
        {
            _mapper = mapper;
            _userAppServices = userAppServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var results = await _userAppServices.GetAllUsers(cancellationToken);
            users = _mapper.Map<List<UserVM>>(results);
        }

        public async Task<IActionResult> OnPostActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _userAppServices.Active(id, cancellationToken);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _userAppServices.DeActive(id, cancellationToken);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _userAppServices.Delete(id, cancellationToken);
            }

            return Page();
        }
    }
}
