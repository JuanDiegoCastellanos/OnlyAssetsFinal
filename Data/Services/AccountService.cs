using onlyassets.Data.ViewModels;
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

        public Task AddNewAccountAsync(NewAccountVM data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccountAsync(NewAccountVM data)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NewAccountDropdownsVM> GetNewAccountDropdownsValues()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccountAsync(NewAccountVM data)
        {
            throw new NotImplementedException();
        }
    }
}