using System.ComponentModel.DataAnnotations;
using OnlyAssetsFinal.Data.Enums;
using ustaTickets.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Role:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public RoleType RoleType { get; set; }

        public List<Account> Accounts { get; set; }

    }
}