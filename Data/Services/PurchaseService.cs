using OnlyAssetsFinal.Models;
using ustaTickets.Data.Base;
using ustaTickets.Data.Services;

namespace OnlyAssetsFinal.Data.Services
{
    public class PurchaseService : EntityBaseRepository<Purchase>, IPurchaseService
    {
        public PurchaseService(ApplicationDbContext context) : base(context)
        {
        }
    }
}