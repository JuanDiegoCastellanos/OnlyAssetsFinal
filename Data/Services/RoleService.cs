using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;
using OnlyAssetsFinal.Data.Services;

namespace OnlyAssetsFinal.Data.Services
{
    public class RoleService : EntityBaseRepository<Role>, IRoleService
    {
        public RoleService(ApplicationDbContext context) : base(context)
        {
        }
    }
}