using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;
using onlyAssets.Data.ViewModels;

namespace OnlyAssetsFinal.Data.Services
{
    public interface IAccountService:IEntityBaseRepository<Account>
    {
        Task<Account> GetAccountByIdAsync(int id);
        Task<NewAccountDropdownsVM> GetNewAccountDropdownsValues();
        Task AddNewAccountAsync(NewAccountVM data);
        Task UpdateAccountAsync(NewAccountVM data);
        Task DeleteAccountAsync(NewAccountVM data);
    }
}
