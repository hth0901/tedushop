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
    [Table("VisitorStatistics")]
    public class VisitorStatistic
    {
        [Key]
        public Guid ID
        {
            get;
            set;
        }
        [Required]
        public DateTime VisitedDate
        {
            get;
            set;
        }
        [MaxLength(50)]
        public string IPAdress
        {
            get;
            set;
        }
    }
}
