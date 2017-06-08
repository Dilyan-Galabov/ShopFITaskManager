using System.ComponentModel.DataAnnotations;

namespace ShopFI.Gateway.DTOs
{
    public class ItemEntry
    {

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Picture URL")]
        public string ImgUrl { get; set; }

        [Required]
        [Phone]
        [StringLength(255)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Categories")]
        public string CategoryId { get; set; }


    }
}