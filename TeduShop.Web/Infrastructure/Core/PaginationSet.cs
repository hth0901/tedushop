using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int MaxPage { get; set; }    //tổng số trang hiển thị
        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }
    }
}