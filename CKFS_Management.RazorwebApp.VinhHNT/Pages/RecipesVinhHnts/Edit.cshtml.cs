using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Services.VinhHNT.Interface;
using CKFS_Management.Repositories.VinhHNT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CKFS_Management.RazorwebApp.VinhHNT.Pages.RecipesVinhHnts;

public class EditModel : PageModel
{
    private readonly IRecipeService _recipeService;
    private readonly ProductsTaiLdRepository _productRepo;

    public EditModel(IRecipeService recipeService, ProductsTaiLdRepository productRepo)
    {
        _recipeService = recipeService;
        _productRepo = productRepo;
    }

    [BindProperty]
    public RecipeVinhHnt RecipeVinhHnt { get; set; } = new();

    public SelectList? ProductIdList { get; set; }
    public SelectList? IngredientIdList { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();
        var recipe = await _recipeService.GetByIdAsync(id);
        if (recipe == null) return NotFound();
        RecipeVinhHnt = recipe;
        var products = await _productRepo.GetAllAsync();
        ProductIdList = new SelectList(products, "ProductId", "Name", recipe.ProductId);
        IngredientIdList = new SelectList(products, "ProductId", "Name", recipe.IngredientId);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        int result = await _recipeService.UpdateAsync(RecipeVinhHnt);
        if (result > 0)
            return RedirectToPage("./Index");
        ModelState.AddModelError(string.Empty, "Cập nhật thất bại.");
        return Page();
    }
}
