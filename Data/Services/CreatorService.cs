using OnlyAssetsFinal.Models;
using ustaTickets.Data.Base;
using ustaTickets.Data.Services;

namespace OnlyAssetsFinal.Data.Services
{
    public class CreatorService : EntityBaseRepository<Creator>, ICreatorService
    {
        public CreatorService(ApplicationDbContext context) : base(context)
        {
        }
    }
}