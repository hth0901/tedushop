using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> LstSlide { get; set; }
        public IEnumerable<ProductViewModel> LstProducts { get; set; }
    }
}