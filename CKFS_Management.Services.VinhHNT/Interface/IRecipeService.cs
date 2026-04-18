using System.Collections.Generic;
using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;

namespace CKFS_Management.Services.VinhHNT.Interface;

public interface IRecipeService
{
    Task<List<RecipeVinhHnt>> GetAllAsync();
    Task<RecipeVinhHnt> GetByIdAsync(int? id);
    Task<List<RecipeVinhHnt>> SearchAsync(string productName, string ingredientName);
    Task<int> CreateAsync(RecipeVinhHnt recipe);
    Task<int> UpdateAsync(RecipeVinhHnt recipe);
    Task<bool> DeleteAsync(int? id);
}
