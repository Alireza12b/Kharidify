using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Endpoints.RazorPages.UI.Areas.Seller.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public UserVM user;

        public ProfileModel(IUserAppServices userAppServices, IMapper mapper, IUserServices userServices)
        {
            _mapper = mapper;
            _userAppServices = userAppServices;
            _userServices = userServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userId, out int currentUserId))
            {
                var results = await _userAppServices.GetById(currentUserId, cancellationToken);
                user = _mapper.Map<UserVM>(results);
            }
        }

        public async Task<IActionResult> OnPostUpdate(UserVM userVM, CancellationToken cancellationToken)
        {
            var userDto = new UserDto() 
            {   Id = userVM.Id,
                FirstName = userVM.FirstName,
                LastName = userVM.LastName,
                Email = userVM.Email,
                PhoneNumber = userVM.PhoneNumber,
            };
            await _userServices.Update(userDto, cancellationToken);
            return RedirectToPage("Profile");
        }
    }
}
    