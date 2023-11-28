using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Users.Contracts;
using App.Domain.Core.Users.DTOs;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Endpoints.RazorPages.UI.Pages
{
    public class profileModel : PageModel
    {
        private readonly IUserServices _userServices;
        private readonly IOrderlineServices _orderlineServices;
        private readonly IMapper _mapper;

        public profileModel(IUserServices userServices, IMapper mapper, IOrderlineServices orderlineServices)
        {
            _userServices = userServices;
            _mapper = mapper;
            _orderlineServices = orderlineServices;
        }

        public UserVM user;
        public List<OrderLineVM> orderlines;

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            user = _mapper.Map<UserVM>(await _userServices.GetById(userId, cancellationToken));
            var result = _mapper.Map<List<OrderLineVM>>(await _orderlineServices.GetByUserId(userId, cancellationToken));
            orderlines = result;
        }

        public async Task<IActionResult> OnPostUpdate(UserVM userVM, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var userDto = new UserDto()
            {
                Id = userId,
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
