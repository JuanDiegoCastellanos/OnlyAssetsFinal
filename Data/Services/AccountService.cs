using Microsoft.EntityFrameworkCore;
using onlyAssets.Data.ViewModels;
using OnlyAssetsFinal.Data.Base;
using OnlyAssetsFinal.Models;
namespace OnlyAssetsFinal.Data.Services
{
    public class AccountService : EntityBaseRepository<Account>, IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewAccountAsync(NewAccountVM data)
        {
            var newAccount = new Account()
            {
                Email = data.Email,
                Password = data.Password,
                NickName = data.NickName,
                CreationDate = data.CreationDate,
                CountryCreation = data.CountryCreation,
                ProfilePictureURL = data.ProfilePictureURL,
                PersonId = data.PersonId,
                RoleId = data.RoleId
            };
            await _context.Account.AddAsync(newAccount);
            await _context.SaveChangesAsync();

            // Add Purchases Asset
            foreach (var assetId in data.AssetsIds)
            {
                var newPurchase = new Purchase() 
                { 
                    AccountId = newAccount.Id,
                    AssetId = assetId 
                };
                await _context.Purchase.AddAsync(newPurchase);
            }
            await _context.SaveChangesAsync();
        }

        public Task DeleteAccountAsync(NewAccountVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            var accountDetails = await _context.Account
                .Include(p => p.Person)
                .Include(r => r.Role)
                .Include(p => p.Purchases)
                .ThenInclude(a => a.Asset)
                .FirstOrDefaultAsync(a => a.Id == id);

            return accountDetails;
        }

        public async Task<NewAccountDropdownsVM> GetNewAccountDropdownsValues()
        {
            var response = new NewAccountDropdownsVM()
            {
                Persons = await _context.Person.OrderBy(p => p.FullName).ToListAsync(),
                Roles = await _context.Role.OrderBy(r => r.RoleType).ToListAsync(),
                Assets = await _context.Asset.OrderBy(a => a.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateAccountAsync(NewAccountVM data)
        {
            var dbAccount = await _context.Account.FirstOrDefaultAsync(a => a.Id == data.Id);
            if (dbAccount != null)
            {

                dbAccount.Email = data.Email;
                dbAccount.Password = data.Password;
                dbAccount.NickName = data.NickName;
                dbAccount.CreationDate = data.CreationDate;
                dbAccount.CountryCreation = data.CountryCreation;
                dbAccount.ProfilePictureURL = data.ProfilePictureURL;
                dbAccount.RoleId = data.RoleId;
                dbAccount.PersonId = data.PersonId;

                await _context.SaveChangesAsync();
            }

            // Remove existing assets
            var existingAcccountDb = await _context.Purchase.Where(a => a.AccountId == data.Id).ToListAsync();
            _context.Purchase.RemoveRange(existingAcccountDb);
            await _context.SaveChangesAsync();

            // Add Purchase Asset
            foreach (var assetId in data.AssetsIds)
            {
                var newPurchase = new Purchase()
                {
                    AccountId = data.Id,
                    AssetId = assetId
                };
                await _context.Purchase.AddAsync(newPurchase);
            }
            await _context.SaveChangesAsync();
        }
    }
}