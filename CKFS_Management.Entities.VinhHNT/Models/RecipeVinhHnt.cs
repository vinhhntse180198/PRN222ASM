#nullable disable
using System;
using System.ComponentModel.DataAnnotations;

namespace CKFS_Management.Entities.VinhHNT.Models;

public class RecipeVinhHnt
{
    public int RecipeId { get; set; }
    [Required(ErrorMessage = "RecipeId Name is required")]
    public int? ProductId { get; set; }
    [Required(ErrorMessage = "ProductId Name is required")]
    public int? IngredientId { get; set; }
    [Required(ErrorMessage = "IngredientId Name is required")]
    public decimal? Quantity { get; set; }
    [Required(ErrorMessage = "Quantity Name is required")]
    public string Unit { get; set; }
    [Required(ErrorMessage = "Unit Name is required")]
    public int? Version { get; set; }
    [Required(ErrorMessage = "Version Name is required")]
    public DateTime? CreatedAt { get; set; }
    [Required(ErrorMessage = "CreatedAt Name is required")]

    public virtual ProductTaiLd Product { get; set; }
    public virtual ProductTaiLd Ingredient { get; set; }
}
