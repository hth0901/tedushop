using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Service;
using TeduShop.Common;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;
using AutoMapper;
using TeduShop.Model.Models;

namespace TeduShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }
        // GET: Product
        public ActionResult Detail(int id)
        {
            return View();
        }

        public ActionResult Category(int id, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var lstProductModel = this._productService.GetListProductByCategoryIdPaging(id, page, pageSize, out totalRow);

            var lstProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lstProductModel);

            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var category = this._productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);

            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = lstProductViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }
    }
}