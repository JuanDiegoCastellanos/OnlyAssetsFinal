using System.ComponentModel.DataAnnotations;
using OnlyAssetsFinal.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Creator:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactNumber { get; set; }

        public string  ProfilePictureURL { get; set; }
        
        public List<Asset> Assets { get; set; }
        
    }
}