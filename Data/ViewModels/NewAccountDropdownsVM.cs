using OnlyAssetsFinal.Models;

namespace onlyAssets.Data.ViewModels
{
    public class NewAccountDropdownsVM
    {
        public List<Role> Roles { get; set; }
        public List<Person> Persons { get; set; }
        public List<Asset> Assets {get; set;}
        public NewAccountDropdownsVM()
        {
            Roles = new List<Role>();
            Persons = new List<Person>();
            Assets = new List<Asset>();
        }

    }
}
