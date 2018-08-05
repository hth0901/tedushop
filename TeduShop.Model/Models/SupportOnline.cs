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
    [Table("SupportOnline")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
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
        [MaxLength(50)]
        public string Department
        {
            get;
            set;
        }
        [MaxLength(50)]
        public string Skype
        {
            get;
            set;
        }
        [MaxLength(50)]
        public string Mobile
        {
            get;
            set;
        }
        [MaxLength(50)]
        public string Email
        {
            get;
            set;
        }
        [MaxLength(50)]
        public string Yahoo
        {
            get;
            set;
        }
        [MaxLength(50)]
        public string Facebook
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }
    }
}
