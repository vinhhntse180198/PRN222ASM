using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Repositories.VinhHNT.Base;
using CKFS_Management.Repositories.VinhHNT.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CKFS_Management.Repositories.VinhHNT;

public class UserAccountRepository : GenericRepository<UserAccount>
{
    public UserAccountRepository() { }
    public UserAccountRepository(CKFS_ManagementContext context) => _context = context;

    public async Task<UserAccount> GetUserAsync(string userName, string password)
    {
        return await _context.UserAccounts
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => (u.UserName == userName || u.Email == userName) && u.Password == password)
            ?? new UserAccount();
    }
}
