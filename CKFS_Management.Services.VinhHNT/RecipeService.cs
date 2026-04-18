using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Repositories.VinhHNT;
using CKFS_Management.Services.VinhHNT.Interface;

namespace CKFS_Management.Services.VinhHNT;

public class RecipeService : IRecipeService
{
    private readonly RecipesVinhHntRepository _repo;

    public RecipeService(RecipesVinhHntRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> CreateAsync(RecipeVinhHnt recipe)
    {
        try
        {
            return await _repo.CreateAsync(recipe);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<bool> DeleteAsync(int? id)
    {
        try
        {
            var item = await _repo.GetByIdAsync(id);
            if (item != null)
                return await _repo.RemoveAsync(item);
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<RecipeVinhHnt>> GetAllAsync()
    {
        try
        {
            return await _repo.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<RecipeVinhHnt> GetByIdAsync(int? id)
    {
        try
        {
            return await _repo.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<RecipeVinhHnt>> SearchAsync(string productName, string ingredientName)
    {
        try
        {
            return await _repo.SearchAsync(productName, ingredientName);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<int> UpdateAsync(RecipeVinhHnt recipe)
    {
        try
        {
            return await _repo.UpdateAsync(recipe);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
