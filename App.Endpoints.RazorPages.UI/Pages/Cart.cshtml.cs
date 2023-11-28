using App.Domain.Core.Products.Contracts.AppServices;
using App.Domain.Core.Products.Contracts.Services;
using App.Domain.Core.Products.DTOs;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace App.Endpoints.RazorPages.UI.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductAppServices _productAppServices;
        private readonly IOrderlineServices _orderlineServices;
        private readonly IBuyServices _buyServices;
        private readonly IMapper _mapper;

        public CartModel(IMapper mapper, IProductAppServices productAppServices, IOrderlineServices orderlineServices, IBuyServices buyServices)
        {
            _mapper = mapper;
            _productAppServices = productAppServices;
            _orderlineServices = orderlineServices;
            _buyServices = buyServices;
        }

        public List<CartVM> orders;

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var neworders = new List<CartVM>();
            var orderlins = await _orderlineServices.GetAll(cancellationToken);
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var cart = await _orderlineServices.FindCartByUserId(userId, cancellationToken);
            neworders = _mapper.Map<List<CartVM>>(orderlins.Where(x => x.CartId == cart.Id && x.IsDeleted == false));
            foreach (var item in neworders)
            {
                item.ProductName = (await _productAppServices.GetById(item.ProductId, cancellationToken)).Name;
                item.ProductPrice = (await _productAppServices.GetById(item.ProductId, cancellationToken)).LastPrice;
                item.SumProductPrice = item.ProductPrice * item.Quantity;
            }

            orders = neworders;
        }

        public async Task<IActionResult> OnPostDelete(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _orderlineServices.DeleteById(id, cancellationToken);
                return RedirectToPage("Cart");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostBuy(CancellationToken cancellationToken)
        {
            var neworders = new List<CartVM>();
            var orderlins = await _orderlineServices.GetAll(cancellationToken);
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var cart = await _orderlineServices.FindCartByUserId(userId, cancellationToken);
            neworders = _mapper.Map<List<CartVM>>(orderlins.Where(x => x.CartId == cart.Id && x.IsDeleted == false));
            foreach (var item in neworders)
            {
                item.ProductName = (await _productAppServices.GetById(item.ProductId, cancellationToken)).Name;
                item.ProductPrice = (await _productAppServices.GetById(item.ProductId, cancellationToken)).LastPrice;
                item.SumProductPrice = item.ProductPrice * item.Quantity;
            }

            orders = neworders;

            if (ModelState.IsValid)
            {
                await _buyServices.Buy(_mapper.Map<List<OrderLineInputDto>>(orders), cancellationToken);
                return RedirectToPage("Cart");
            }

            return Page();
        }
    }
}
