using ShopFI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFI.Entities.Common
{
    public class Comments
    {

        public Comments()
        { }

        public Comments(string author, string comment, CustomId id = null) 
            : this(id)
        {
            this.Author = author;
            this.Comment = comment;

        }

        public Comments(CustomId id)
        {
            this.Id = string.IsNullOrEmpty(Convert.ToString(id)) ? new CustomId().ToString() : id.ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
