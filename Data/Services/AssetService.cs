using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Base;

namespace OnlyAssetsFinal.Data.Services
{
    public class AssetService : EntityBaseRepository<Asset>, IAssetService
    {
        public AssetService(ApplicationDbContext context) : base(context)
        {
            
        }        
    }
}