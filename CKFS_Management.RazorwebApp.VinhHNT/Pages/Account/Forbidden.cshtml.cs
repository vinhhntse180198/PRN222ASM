using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CKFS_Management.RazorwebApp.VinhHNT.Pages.Account;

[AllowAnonymous]
public class ForbiddenModel : PageModel
{
    public void OnGet()
    {
    }
}
