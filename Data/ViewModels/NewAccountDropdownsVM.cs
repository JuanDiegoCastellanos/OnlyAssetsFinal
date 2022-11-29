using OnlyAssetsFinal.Models;

namespace onlyassets.Data.ViewModels
{
    public class NewAccountDropdownsVM
    {
        public List<Role> Roles { get; set; }
        public List<Person> Persons { get; set; }
        public List<Purchase> Purchases {get; set;}
        public NewAccountDropdownsVM()
        {
            Roles = new List<Role>();
            Persons = new List<Person>();
            Purchases = new List<Purchase>();
        }

    }
}
