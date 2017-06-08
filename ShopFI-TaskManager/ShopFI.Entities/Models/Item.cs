using ShopFI.Common;
using ShopFI.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFI.Entities.Models
{
    public class Item
    {
        public Item() { }


        public Item(string performerId, string categoryId, string title, string description,string imgUrl,
            string phoneNumber,DateTime dateCreated,DateTime? dateModified,CustomId id = null)
            :this(id)
        {
            this.PerformerId = performerId;
            this.CategoryId = categoryId;
            this.Title = title;
            this.Description = description;
            this.ImgUrl = imgUrl;
            this.PhoneNumber = phoneNumber;        
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }

        public Item(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        public string ImgUrl { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }


        [Required]
        public string PerformerId { get; set; }

        public virtual User Performer { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }


        [Required]
        public DateTime DateCreated { get; set; }

        
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }



    }
}
