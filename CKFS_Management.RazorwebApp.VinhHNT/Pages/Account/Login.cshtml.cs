using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Services.VinhHNT.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace CKFS_Management.RazorwebApp.VinhHNT.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly IAccountService _accountService;

    public LoginModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty]
    public string UserName { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        UserAccount user = await _accountService.GetUserAsync(UserName, Password);
        if (user?.UserAccountId == 0 || user == null)
        {
            TempData["Message"] = "Sai tên đăng nhập hoặc mật khẩu.";
            return Page();
        }
        if (user.IsActive == false)
        {
            TempData["Message"] = "Tài khoản đã bị khóa.";
            return Page();
        }
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName ?? user.Email ?? ""),
            new Claim(ClaimTypes.Role, (user.RoleId ?? 0).ToString())
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        return RedirectToPage("/RecipesVinhHnts/Index");
    }
}
