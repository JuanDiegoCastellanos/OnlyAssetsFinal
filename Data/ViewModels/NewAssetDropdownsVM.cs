using OnlyAssetsFinal.Models;

namespace OnlyAssetsFinal.Data.ViewModels
{
    public class NewAssetDropdownsVM
    {
        public List<Creator> Creators { get; set; }
        public List<Account> Accounts {get; set;}
        public NewAssetDropdownsVM()
        {
            Creators = new List<Creator>();
            Accounts = new List<Account>();
        }

    }
}
