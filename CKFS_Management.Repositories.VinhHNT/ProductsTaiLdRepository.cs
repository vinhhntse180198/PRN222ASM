using System.Collections.Generic;
using System.Threading.Tasks;
using CKFS_Management.Entities.VinhHNT.Models;
using CKFS_Management.Repositories.VinhHNT.Base;
using CKFS_Management.Repositories.VinhHNT.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CKFS_Management.Repositories.VinhHNT;

public class ProductsTaiLdRepository : GenericRepository<ProductTaiLd>
{
    public ProductsTaiLdRepository() { }
    public ProductsTaiLdRepository(CKFS_ManagementContext context) => _context = context;

    public async Task<List<ProductTaiLd>> GetAllAsync()
    {
        return await _context.ProductsTaiLd
            .AsNoTracking()
            .ToListAsync();
    }
}
