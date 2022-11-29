using OnlyAssetsFinal.Models;

namespace onlyassets.Data.ViewModels
{
    public class NewCreatorDropdownVM
    {
        public List<Asset> Assets { get; set; }
        public NewCreatorDropdownVM()
        {
            Assets = new List<Asset>();
        }

    }
}
