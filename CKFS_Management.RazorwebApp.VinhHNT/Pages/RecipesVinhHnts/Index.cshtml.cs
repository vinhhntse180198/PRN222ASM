using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Services.VinhHNT.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CKFS_Management.RazorwebApp.VinhHNT.Pages.RecipesVinhHnts;

public class IndexModel : PageModel
{
    private readonly IRecipeService _recipeService;

    public IndexModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    public List<RecipeVinhHnt> Recipes { get; set; } = new();

    public async Task OnGetAsync()
    {
        Recipes = await _recipeService.GetAllAsync();
    }
}
