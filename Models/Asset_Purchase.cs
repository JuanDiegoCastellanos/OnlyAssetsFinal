using System.ComponentModel.DataAnnotations.Schema;

namespace OnlyAssetsFinal.Models
{
    public class Asset_Purchase
    {
        
        public int AssetId{ get; set; }
        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }
        
        public int PurchaseId{ get; set; }
        [ForeignKey("PurchaseId")]
        public Purchase Purchase { get; set; }
        
        
        
        
        
        
    
    }
}