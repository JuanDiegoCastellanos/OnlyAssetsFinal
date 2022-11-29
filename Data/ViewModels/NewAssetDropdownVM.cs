using OnlyAssetsFinal.Models;

namespace onlyassets.Data.ViewModels
{
    public class NewAssetDropdownsVM
    {
        public List<Creator> Creators { get; set; }
        public List<Purchase> Purchases {get; set;}
        public NewAssetDropdownsVM()
        {
            Creators = new List<Creator>();
            Purchases = new List<Purchase>();
        }

    }
}
