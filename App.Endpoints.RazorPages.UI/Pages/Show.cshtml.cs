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
        private readonly ICommentServices _commentServices;
        private readonly IMapper _mapper;
        int productid;

        public ShowModel(IMapper mapper, IProductAppServices productAppServices, IOrderlineServices orderlineServices, ICommentServices commentServices)
        {
            _mapper = mapper;
            _productAppServices = productAppServices;
            _orderlineServices = orderlineServices;
            _commentServices = commentServices;
        }

        public ProductVM products;
        public List<CommentVM> comments;

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            productid = id;
            products = _mapper.Map<ProductVM>(await _productAppServices.GetById(id, cancellationToken));
            var commentResult = _mapper.Map<List<CommentVM>>(await _commentServices.GetAll(cancellationToken));
            comments = _mapper.Map<List<CommentVM>>(commentResult.Where(x => x.ProductId == id).ToList());
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

        public async Task<IActionResult> OnPostComment(CommentVM commentVM, CancellationToken cancellationToken)
        {


            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            commentVM.UserId = userId;
            await _commentServices.Create(_mapper.Map<CommentInputDto>(commentVM), cancellationToken);

            return RedirectToPage("Show");

        }

    }
}
