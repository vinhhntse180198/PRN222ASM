#nullable disable
using System;

namespace CKFS_Management.Entities.VinhHNT.Models;

public class UserAccount
{
    public int UserAccountId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string EmployeeCode { get; set; }
    public int? RoleId { get; set; }
    public int? StoreId { get; set; }
    public string BusinessRole { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public virtual Role Role { get; set; }
}
