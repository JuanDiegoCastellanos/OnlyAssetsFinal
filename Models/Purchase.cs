using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyAssetsFinal.Models
{
    public class Purchase
    {
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public Asset Asset {get; set; }
        
    }
}