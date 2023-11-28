using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using App.Domain.Core.Products.Entities;
using App.Domain.Services;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Endpoints.RazorPages.UI.Pages
{
    [Authorize]
    public class ShowModel : PageModel
    {
        private readonly IProductAppServices _productAppServices;
        private readonly IOrderlineServices _orderlineServices;
        private readonly IMapper _mapper;

        public ShowModel(IMapper mapper, IProductAppServices productAppServices, IOrderlineServices orderlineServices)
        {
            _mapper = mapper;
            _productAppServices = productAppServices;
            _orderlineServices = orderlineServices;
        }

        public ProductVM products;

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            products = _mapper.Map<ProductVM>(await _productAppServices.GetById(id, cancellationToken));
        }

        public async Task<IActionResult> OnPostCreate(OrderLineVM orderLine, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var cart = await _orderlineServices.FindCartByUserId(userId, cancellationToken);

                var newOrderLine = new OrderLineInputDto()
                {
                    CartId = cart.Id,
                    ProductId = orderLine.ProductId,
                    Quantity = orderLine.Quantity,
                    IsDeleted = false,
                    IsPaid = false,
                };

                await _orderlineServices.Create(newOrderLine, cancellationToken);
                return RedirectToPage("Show");
            }
            else
            {
                return RedirectToPage("Show");
            }
        }

        
    }
}
