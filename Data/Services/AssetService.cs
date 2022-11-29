using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;
using OnlyAssetsFinal.Data.Services;
using OnlyAssetsFinal.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteAssetAsync(NewAssetVM data)
        {
            
            var dbAsset = await _context.Asset.FirstOrDefaultAsync(a => a.Id == data.Id);
            if (dbAsset != null)
            {
                _context.Remove(dbAsset);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Asset> GetAssetByIdAsync(int id)
        {
            var assetDetails = await _context.Asset
                .Include(c => c.Creator)
                .Include(p => p.Purchases)
                .ThenInclude(a => a.Account)
                .FirstOrDefaultAsync(a => a.Id == id);

            return assetDetails;
        }

        public async Task<NewAssetDropdownsVM> GetNewAssetDropdownsValues()
        {
            var response = new NewAssetDropdownsVM()
            {
                Creators = await _context.Creator.OrderBy(c => c.CompanyName).ToListAsync(),
                Accounts = await _context.Account.OrderBy(a => a.NickName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateAssetAsync(NewAssetVM data)
        {
            var dbAsset = await _context.Asset.FirstOrDefaultAsync(a => a.Id == data.Id);
            if (dbAsset != null)
            {

                dbAsset.Name = data.Name;
                dbAsset.AssetType = data.AssetType;
                dbAsset.AssetImageUrl = data.AssetImageUrl;
                dbAsset.Price = data.Price;
                dbAsset.Rating = data.Rating;
                dbAsset.CreatorId = data.CreatorId;
                
                await _context.SaveChangesAsync();
            }

            // Remove existing accounts
            var existingAcccountDb = await _context.Purchase.Where(a => a.AssetId == data.Id).ToListAsync();
            _context.Purchase.RemoveRange(existingAcccountDb);
            await _context.SaveChangesAsync();

            // Add Purchase Account
            foreach (var accountId in data.AccountsIds)
            {
                var newPurchase = new Purchase()
                {
                    AssetId = data.Id,
                    AccountId = accountId
                };
                await _context.Purchase.AddAsync(newPurchase);
            }
            await _context.SaveChangesAsync();
        }
    }
}