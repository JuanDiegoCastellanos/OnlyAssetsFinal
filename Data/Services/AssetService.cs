using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;
using OnlyAssetsFinal.Data.Services;
using OnlyAssetsFinal.Data.ViewModels;

namespace OnlyAssetsFinal.Data.Services
{
    public class AssetService : EntityBaseRepository<Asset>, IAssetService
    {
        private readonly ApplicationDbContext _context;
        public AssetService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewAssetAsync(NewAssetVM data)
        {
            var newAsset = new Asset()
            {
                Name = data.Name,
                AssetType = data.AssetType,
                Price = data.Price,
                Rating = data.Rating,
                CreatorId = data.CreatorId,
            };
            await _context.Asset.AddAsync(newAsset);
            await _context.SaveChangesAsync();

            // Add Asset Accounts
            foreach (var accountId in data.AccountsIds)
            {
                var newPurchase = new Purchase() 
                { 
                    AssetId = newAsset.Id,
                    AccountId = accountId 
                };
                await _context.Purchase.AddAsync(newPurchase);
            }
            await _context.SaveChangesAsync();
        }

        public Task DeleteAssetAsync(NewAssetVM data)
        {
            throw new NotImplementedException();
        }

        public Task<Asset> GetAssetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NewAssetDropdownsVM> GetNewAssetDropdownsValues()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAssetAsync(NewAssetVM data)
        {
            throw new NotImplementedException();
        }
    }
}