using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Services.VinhHNT.Interface;
using Microsoft.AspNetCore.SignalR;

namespace CKFS_Management.RazorwebApp.VinhHNT.Hubs;

public class RecipesHub : Hub
{
    private readonly IRecipeService _recipeService;

    public RecipesHub(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    public async Task HubCreate_Recipe(RecipeVinhHnt recipe)
    {
        try
        {
            int result = await _recipeService.CreateAsync(recipe);
            if (result > 0)
            {
                var created = await _recipeService.GetByIdAsync(recipe.RecipeId);
                var payload = new
                {
                    recipeId = created.RecipeId,
                    productId = created.ProductId,
                    ingredientId = created.IngredientId,
                    quantity = created.Quantity,
                    unit = created.Unit ?? "-",
                    version = created.Version,
                    productName = created.Product?.Name ?? "-",
                    ingredientName = created.Ingredient?.Name ?? "-"
                };
                await Clients.Caller.SendAsync("CreateSuccess", payload);
                await Clients.All.SendAsync("ReceiveCreate_Recipe", payload);
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveErrorRecipe", "Không thể tạo công thức.");
            }
        }
        catch (Exception ex)
        {
            await Clients.Caller.SendAsync("ReceiveErrorRecipe", "Lỗi: " + ex.Message);
        }
    }

    public async Task HubUpdate_Recipe(RecipeVinhHnt recipe)
    {
        try
        {
            int result = await _recipeService.UpdateAsync(recipe);
            if (result > 0)
            {
                var updated = await _recipeService.GetByIdAsync(recipe.RecipeId);
                var payload = new
                {
                    recipeId = updated.RecipeId,
                    productId = updated.ProductId,
                    ingredientId = updated.IngredientId,
                    quantity = updated.Quantity,
                    unit = updated.Unit ?? "-",
                    version = updated.Version,
                    productName = updated.Product?.Name ?? "-",
                    ingredientName = updated.Ingredient?.Name ?? "-"
                };
                await Clients.Caller.SendAsync("UpdateSuccess", payload);
                await Clients.All.SendAsync("ReceiveUpdate_Recipe", payload);
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveErrorRecipe", "Không thể cập nhật công thức.");
            }
        }
        catch (Exception ex)
        {
            await Clients.Caller.SendAsync("ReceiveErrorRecipe", "Lỗi: " + ex.Message);
        }
    }

    public async Task HubDelete_Recipe(int recipeId)
    {
        try
        {
            bool isDeleted = await _recipeService.DeleteAsync(recipeId);
            if (isDeleted)
            {
                await Clients.Caller.SendAsync("DeleteSuccess");
                await Clients.Others.SendAsync("ReceiveDelete_Recipe", recipeId);
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveErrorRecipe", "Không tìm thấy công thức để xóa.");
            }
        }
        catch (Exception ex)
        {
            await Clients.Caller.SendAsync("ReceiveErrorRecipe", "Lỗi: " + ex.Message);
        }
    }
}
