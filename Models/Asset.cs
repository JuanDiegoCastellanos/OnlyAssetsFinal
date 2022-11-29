using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlyAssetsFinal.Data.Enums;
using ustaTickets.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Asset:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public AssetType AssetType { get; set; }

        public string AssetImageUrl { get; set; }

        public double Price { get; set; }

        public double Rating { get; set; }

        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public Creator Creator { get; set; }

        public List<Asset_Purchase>  Asset_Purchases{ get; set; }
        
    }
}