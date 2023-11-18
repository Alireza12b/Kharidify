using App.Domain.Core.Products.Contracts.AppServices;
using App.Endpoints.RazorPages.UI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Admin.Pages
{
    public class ActiveCommentsModel : PageModel
    {
        private readonly ICommentAppServices _commentAppServices;
        private readonly IMapper _mapper;

        public List<CommentVM> comments;

        public ActiveCommentsModel(ICommentAppServices commentAppServices, IMapper mapper)
        {
            _commentAppServices = commentAppServices;
            _mapper = mapper;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var result = await _commentAppServices.GetAll(cancellationToken);
            comments = _mapper.Map<List<CommentVM>>(result);
        }

        public async Task<IActionResult> OnPostActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _commentAppServices.Active(id, cancellationToken);
                return RedirectToPage("ActiveComments");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeActive(int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _commentAppServices.Deactive(id, cancellationToken);
                return RedirectToPage("ActiveComments");
            }

            return Page();
        }
    }
}
