
using System.ComponentModel.DataAnnotations;

namespace OnlyAssetsFinal.Data.ViewModels
{
    public class NewCreatorVM
    {
       public int Id { get; set; }

        [Display(Name = "Creator Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Creator Contact Number")]
        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; }

        [Display(Name = "Creator ProfilePictureURL")]
        [Required(ErrorMessage = "ProfilePictureURL is required")]
        public string ProfilePictureURL { get; set; }


        [Display(Name = "Select Asset(s)")]
        [Required(ErrorMessage = "Asset(s) is required")]
        public List<int> AssetIds { get; set; }

    }
}
