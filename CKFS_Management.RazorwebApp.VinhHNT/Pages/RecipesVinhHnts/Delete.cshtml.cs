using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Services.VinhHNT.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CKFS_Management.RazorwebApp.VinhHNT.Pages.RecipesVinhHnts;

public class DeleteModel : PageModel
{
    private readonly IRecipeService _recipeService;

    public DeleteModel(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [BindProperty]
    public RecipeVinhHnt RecipeVinhHnt { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();
        var recipe = await _recipeService.GetByIdAsync(id);
        if (recipe == null) return NotFound();
        RecipeVinhHnt = recipe;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();
        bool result = await _recipeService.DeleteAsync(id);
        if (!result) return NotFound();
        return RedirectToPage("./Index");
    }
}
