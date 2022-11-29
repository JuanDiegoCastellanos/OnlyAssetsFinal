using System.ComponentModel.DataAnnotations;
using OnlyAssetsFinal.Data.Base;

namespace OnlyAssetsFinal.Models
{
    public class Person:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string Name { get; set; }

        [Display(Name = "SurName")]
        [Required(ErrorMessage = "SurName is required")]
        public string SurName { get; set; }

        [Display(Name = "Fullname")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 chars.")]
        public string FullName { get; set; }

        [Display(Name = "BirthDate")]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        
        public List<Account> Accounts { get; set; }
        
    }
}