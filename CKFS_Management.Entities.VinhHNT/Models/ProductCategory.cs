#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CKFS_Management.Entities.VinhHNT.Models;

public class ProductCategory
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Category Name is required")]
    public string Code { get; set; }
    [Required(ErrorMessage = "Code Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Name Name is required")]
    public int? ParentId { get; set; }
    [Required(ErrorMessage = "Parent Name is required")]
    public string Status { get; set; }
    [Required(ErrorMessage = "Status Name is required")]
    public DateTime? CreatedAt { get; set; }
    [Required(ErrorMessage = "CreatedAt Name is required")]

    public virtual ProductCategory Parent { get; set; }
    public virtual ICollection<ProductCategory> InverseParent { get; set; } = new List<ProductCategory>();
    public virtual ICollection<ProductTaiLd> Products { get; set; } = new List<ProductTaiLd>();
}
