using OnlyAssetsFinal.Models;
using ustaTickets.Data.Base;
using ustaTickets.Data.Services;

namespace OnlyAssetsFinal.Data.Services
{
    public class RoleService : EntityBaseRepository<Role>, IRoleService
    {
        public RoleService(ApplicationDbContext context) : base(context)
        {
        }
    }
}