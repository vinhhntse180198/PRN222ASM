using System;
using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Repositories.VinhHNT;
using CKFS_Management.Services.VinhHNT.Interface;

namespace CKFS_Management.Services.VinhHNT;

public class UserAccountService : IAccountService
{
    private readonly UserAccountRepository _userAccountRepository;

    public UserAccountService(UserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public async Task<UserAccount> GetUserAsync(string userName, string password)
    {
        try
        {
            return await _userAccountRepository.GetUserAsync(userName, password);
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving user.", ex);
        }
    }
}
