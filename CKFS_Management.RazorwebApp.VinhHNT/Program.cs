using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.RazorwebApp.VinhHNT.Hubs;
using CKFS_Management.Repositories.VinhHNT;
using CKFS_Management.Repositories.VinhHNT.DBContext;
using CKFS_Management.Services.VinhHNT;
using CKFS_Management.Services.VinhHNT.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddDbContext<CKFS_ManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IAccountService, UserAccountService>();
builder.Services.AddScoped<RecipesVinhHntRepository>();
builder.Services.AddScoped<ProductsTaiLdRepository>();
builder.Services.AddScoped<UserAccountRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Account/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        options.LoginPath = "/Account/Login";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();
app.MapHub<RecipesHub>("/recipesHub");

app.Run();
