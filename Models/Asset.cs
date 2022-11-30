using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlyAssetsFinal.Data.Enums;
using OnlyAssetsFinal.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Asset:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Asset")]
        [Required(ErrorMessage = "Asset is required")]
        public AssetType AssetType { get; set; }

        [Display(Name = "Asset Picture")]
        [Required(ErrorMessage = "Asset Picture is required")]
        public string AssetImageUrl { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Rating")]
        public double? Rating { get; set; }

        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public Creator Creator { get; set; }

        public List<Purchase> Purchases { get; set; }
        
    }
}