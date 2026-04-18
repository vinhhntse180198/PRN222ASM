#nullable disable
using System.ComponentModel.DataAnnotations;

namespace CKFS_Management.Entities.VinhHNT.Models;

public class Role
{
    public int RoleId { get; set; }
    [Required(ErrorMessage = "RoleId Name is required")]
    public string RoleName { get; set; }

    [Required(ErrorMessage = "RoleName Name is required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Description Name is required")]

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
