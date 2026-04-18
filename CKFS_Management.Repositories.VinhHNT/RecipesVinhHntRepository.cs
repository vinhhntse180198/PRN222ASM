using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Repositories.VinhHNT.Base;
using CKFS_Management.Repositories.VinhHNT.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CKFS_Management.Repositories.VinhHNT;

public class RecipesVinhHntRepository : GenericRepository<RecipeVinhHnt>
{
    public RecipesVinhHntRepository() { }
    public RecipesVinhHntRepository(CKFS_ManagementContext context) => _context = context;

    public async Task<List<RecipeVinhHnt>> GetAllAsync()
    {
        var items = await _context.RecipesVinhHnt
            .Include(r => r.Product)
            .Include(r => r.Ingredient)
            .ToListAsync();
        return items ?? new List<RecipeVinhHnt>();
    }

    public new async Task<RecipeVinhHnt?> GetByIdAsync(int? id)
    {
        if (id == null) return null;
        return await _context.RecipesVinhHnt
            .Include(r => r.Product)
            .Include(r => r.Ingredient)
            .FirstOrDefaultAsync(r => r.RecipeId == id.Value);
    }

    public async Task<List<RecipeVinhHnt>> SearchAsync(string productName, string ingredientName)
    {
        return await _context.RecipesVinhHnt
            .Include(r => r.Product)
            .Include(r => r.Ingredient)
            .Where(r =>
                (string.IsNullOrEmpty(productName) || (r.Product != null && r.Product.Name != null && r.Product.Name.Contains(productName))) &&
                (string.IsNullOrEmpty(ingredientName) || (r.Ingredient != null && r.Ingredient.Name != null && r.Ingredient.Name.Contains(ingredientName)))
            )
            .OrderBy(r => r.RecipeId)
            .ToListAsync();
    }
}
