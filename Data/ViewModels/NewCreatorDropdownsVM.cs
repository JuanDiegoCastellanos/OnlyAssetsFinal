using OnlyAssetsFinal.Models;

namespace OnlyAssetsFinal.Data.ViewModels
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
