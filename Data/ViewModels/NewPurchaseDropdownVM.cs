using OnlyAssetsFinal.Models;

namespace onlyassets.Data.ViewModels
{
    public class NewPurchaseDropdownVM
    {
        public List<Asset> Assets { get; set; }
        public List<Account> Accounts { get; set; }

        public NewPurchaseDropdownVM()
        {
            Assets = new List<Asset>();
            Accounts = new List<Account>();
        }
    }
}