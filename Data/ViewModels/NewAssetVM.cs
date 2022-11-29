
using System.ComponentModel.DataAnnotations;
using OnlyAssetsFinal.Data.Enums;

namespace OnlyAssetsFinal.Data.ViewModels
{
    public class NewAssetVM
    {
       public int Id { get; set; }

        [Display(Name = "Asset Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Account CreationDate")]
        [Required(ErrorMessage = "CreationDate is required")]
        public AssetType AssetType { get; set; }

        [Display(Name = "Asset AssetImageUrl")]
        [Required(ErrorMessage = "AssetImageUrl is required")]
        public string AssetImageUrl { get; set; }

        [Display(Name = "Asset Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Asset Rating")]
        [Required(ErrorMessage = "Rating is required")]
        public double Rating { get; set; }

        [Display(Name = "Select Creator")]
        [Required(ErrorMessage = "Creator is required")]
        public int CreatorId { get; set; }

        [Display(Name = "Select Account(s)")]
        [Required(ErrorMessage = "Account(s) is required")]
        public List<int> AccountsIds { get; set; }

    }
}
