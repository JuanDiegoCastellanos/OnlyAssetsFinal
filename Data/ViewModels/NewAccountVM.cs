
using System.ComponentModel.DataAnnotations;

namespace OnlyAssetsFinal.Data.ViewModels
{
    public class NewAccountVM
    {
       public int Id { get; set; }

        [Display(Name = " Account Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Account Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Account NickName")]
        [Required(ErrorMessage = "NickName is required")]
        public string NickName { get; set; }

        [Display(Name = "Account CreationDate")]
        [Required(ErrorMessage = "CreationDate is required")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Account CountryCreation")]
        [Required(ErrorMessage = "CountryCreation is required")]
        public string CountryCreation { get; set; }

        [Display(Name = "Account ProfilePictureURL")]
        [Required(ErrorMessage = "ProfilePictureURL is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Select Person")]
        [Required(ErrorMessage = "Person is required")]
        public int PersonId { get; set; }

        [Display(Name = "Select Role")]
        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }

        [Display(Name = "Select Assets(s)")]
        [Required(ErrorMessage = "Assets(s) is required")]
        public List<int> AssetsIds { get; set; }

    }
}
