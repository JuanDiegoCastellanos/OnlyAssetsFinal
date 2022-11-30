using System.ComponentModel.DataAnnotations;
using OnlyAssetsFinal.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Creator:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company")]
        [Required(ErrorMessage = "Company is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string  ProfilePictureURL { get; set; }
        
        public List<Asset>? Assets { get; set; }
        
    }
}