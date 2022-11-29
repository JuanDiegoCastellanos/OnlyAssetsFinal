
using System.ComponentModel.DataAnnotations;

namespace onlyassets.Data.ViewModels
{
    public class NewPurchaseVM
    {
       public int Id { get; set; }

        [Display(Name = "Purchase Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Purchase Total Amount")]
        [Required(ErrorMessage = "Total Amount is required")]
        public double TotalAmount { get; set; }

        [Display(Name = "Select Account")]
        [Required(ErrorMessage = "Account is required")]
        public int AccountId { get; set; }

        [Display(Name = "Select Asset(s)")]
        [Required(ErrorMessage = "Asset(s) is required")]
        public List<int> AssetIds { get; set; }

    }
}
