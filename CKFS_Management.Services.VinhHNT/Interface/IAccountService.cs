using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;

namespace CKFS_Management.Services.VinhHNT.Interface;

public interface IAccountService
{
    Task<UserAccount> GetUserAsync(string userName, string password);
}
