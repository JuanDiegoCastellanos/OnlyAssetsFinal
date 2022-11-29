using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;
using OnlyAssetsFinal.Data.ViewModels;

namespace OnlyAssetsFinal.Data.Services
{
    public interface IAssetService:IEntityBaseRepository<Asset>
    {
        Task<Asset> GetAssetByIdAsync(int id);
        Task<NewAssetDropdownsVM> GetNewAssetDropdownsValues();
        Task AddNewAssetAsync(NewAssetVM data);
        Task UpdateAssetAsync(NewAssetVM data);
        Task DeleteAssetAsync(NewAssetVM data);
    }
}
