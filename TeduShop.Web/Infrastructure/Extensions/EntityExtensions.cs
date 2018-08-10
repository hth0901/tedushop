using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extensions
{
    //tao phuong thuc mo rong cho doi tuong
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Description = postCategoryVm.Description;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;
            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdatePost(this Post des, PostViewModel res)
        {
            des.ID = res.ID;
            des.Name = res.Name;
            des.Alias = res.Alias;
            des.CategoryID = res.CategoryID;
            des.Image = res.Image;
            des.Description = res.Description;
            des.Content = res.Content;
            des.HomeFlag = res.HomeFlag;
            des.HotFlag = res.HotFlag;
            des.ViewCount = res.ViewCount;

            des.CreatedDate = res.CreatedDate;
            des.CreatedBy = res.CreatedBy;
            des.UpdatedDate = res.UpdatedDate;
            des.UpdatedBy = res.UpdatedBy;
            des.MetaKeyword = res.MetaKeyword;
            des.MetaDescription = res.MetaDescription;
            des.Status = res.Status;
        }

        public static void UpdateProductCategory(this ProductCategory des, ProductCategoryViewModel res)
        {
            des.ID = res.ID;
            des.Name = res.Name;
            des.Alias = res.Alias;
            des.Description = res.Description;
            des.ParentID = res.ParentID;
            des.DisplayOrder = res.DisplayOrder;
            des.Image = res.Image;
            des.HomeFlag = res.HomeFlag;

            des.CreatedDate = res.CreatedDate;
            des.CreatedBy = res.CreatedBy;
            des.UpdatedDate = res.UpdatedDate;
            des.UpdatedBy = res.UpdatedBy;
            des.MetaKeyword = res.MetaKeyword;
            des.MetaDescription = res.MetaDescription;
            des.Status = res.Status;
        }

        public static void UpdateProduct(this Product des, ProductViewModel res)
        {
            des.ID = res.ID;
            des.Name = res.Name;
            des.Alias = res.Alias;
            des.CategoryID = res.CategoryID;
            des.Image = res.Image;
            des.MoreImages = res.MoreImages;
            des.Price = res.Price;
            des.PromotionPrice = res.PromotionPrice;
            des.Warranty = res.Warranty;
            des.Description = res.Description;
            des.Content = res.Content;
            des.HomeFlag = res.HomeFlag;
            des.HotFlag = res.HotFlag;
            des.ViewCount = res.ViewCount;

            des.CreatedDate = res.CreatedDate;
            des.CreatedBy = res.CreatedBy;
            des.UpdatedDate = res.UpdatedDate;
            des.UpdatedBy = res.UpdatedBy;
            des.MetaKeyword = res.MetaKeyword;
            des.MetaDescription = res.MetaDescription;
            des.Status = res.Status;
        }
    }
}