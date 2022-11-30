using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;
using OnlyAssetsFinal.Data.Services;
using OnlyAssetsFinal.Data.ViewModels;

namespace OnlyAssetsFinal.Data.Services
{
    public class CreatorService : EntityBaseRepository<Creator>, ICreatorService
    {
        public CreatorService(ApplicationDbContext context) : base(context)
        {
        }

      
    }
}