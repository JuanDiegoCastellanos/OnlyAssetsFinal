using System.ComponentModel.DataAnnotations;
using OnlyAssetsFinal.Data.Enums;
using OnlyAssetsFinal.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Role:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is required")]
        public RoleType RoleType { get; set; }

        public List<Account> Accounts { get; set; }

    }
}