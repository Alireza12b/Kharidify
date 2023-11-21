using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Endpoints.RazorPages.UI.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class PanelModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
