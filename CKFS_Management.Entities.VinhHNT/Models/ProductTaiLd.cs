#nullable disable
using System;
using System.Collections.Generic;

namespace CKFS_Management.Entities.VinhHNT.Models;

public class ProductTaiLd
{
    public int ProductId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int? CategoryId { get; set; }
    public string ProductType { get; set; }
    public string BaseUnit { get; set; }
    public decimal? StandardCost { get; set; }
    public string Status { get; set; }
    public DateTime? CreatedAt { get; set; }

    public virtual ProductCategory Category { get; set; }
    public virtual ICollection<RecipeVinhHnt> RecipesAsProduct { get; set; } = new List<RecipeVinhHnt>();
    public virtual ICollection<RecipeVinhHnt> RecipesAsIngredient { get; set; } = new List<RecipeVinhHnt>();
}
