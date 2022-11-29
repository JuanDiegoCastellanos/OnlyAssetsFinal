using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ustaTickets.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Purchase:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public string Description { get; set; }
        public double TotalAmount { get; set; }

        public List<Asset_Purchase> Asset_Purchases { get; set; }
    }
}