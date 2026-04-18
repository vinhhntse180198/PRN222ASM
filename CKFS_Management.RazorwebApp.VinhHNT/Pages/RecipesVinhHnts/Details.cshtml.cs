using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Services.VinhHNT.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CKFS_Management.RazorwebApp.VinhHNT.Pages.RecipesVinhHnts;

public class DetailsModel : PageModel
{
    private readonly IRecipeService _recipeService;

    public DetailsModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    public RecipeVinhHnt RecipeVinhHnt { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();
        var recipe = await _recipeService.GetByIdAsync(id);
        if (recipe == null) return NotFound();
        RecipeVinhHnt = recipe;
        return Page();
    }
}
