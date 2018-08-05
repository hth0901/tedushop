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
    [Table("Pages")]
    public class Page : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get;
            set;
        }
        [Required]
        [MaxLength(256)]
        public string Name
        {
            get;
            set;
        }
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        [Required]
        public string Alias
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
    }
}
