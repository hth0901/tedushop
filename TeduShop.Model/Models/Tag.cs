using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstract;
using System.Xml.Linq;

namespace TeduShop.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string ID
        {
            get;
            set;
        }
        [Required]
        [MaxLength(50)]
        public string Name
        {
            get;
            set;
        }
        [Required]
        [MaxLength(50)]
        public string Type
        {
            get;
            set;
        }
        public virtual IEnumerable<PostTag> PostTags
        {
            get;
            set;
        }
        public virtual IEnumerable<ProductTag> ProductTags
        {
            get;
            set;
        }
    }
}
