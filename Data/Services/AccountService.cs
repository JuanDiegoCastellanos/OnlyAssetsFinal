using OnlyAssetsFinal.Models;
using ustaTickets.Data.Base;
using ustaTickets.Data.Services;

namespace OnlyAssetsFinal.Data.Services
{
    public class AccountService : EntityBaseRepository<Account>, IAccountService
    {
        public AccountService(ApplicationDbContext context) : base(context)
        {
        }
    }
}