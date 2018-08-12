using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Models;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Common;

namespace TeduShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);
        void Update(Product product);
        Product Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(string keyword);
        IEnumerable<Product> GetAllByParentId(int parentId);
        Product GetById(int id);
        void Save();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWord, ITagRepository tagRepository, IProductTagRepository productTagRepository)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWord;
            this._tagRepository = tagRepository;
            this._productTagRepository = productTagRepository;
        }
        public Product Add(Product product)
        {
            var _product = this._productRepository.Add(product);
            this._unitOfWork.Commit();
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for(var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (this._tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        this._tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
                //this._unitOfWork.Commit();
            }
            return _product;
        }

        public Product Delete(int id)
        {
            return this._productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return this._productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return this._productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            return this._productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByParentId(int parentId)
        {
            //return this._productRepository.GetMulti(x => x.Status && x.ParentID == parentId);
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            return this._productRepository.GetSingleById(id);
        }

        public void Save()
        {
            this._unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            this._productRepository.Update(product);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (this._tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        this._tagRepository.Add(tag);
                    }

                    this._productTagRepository.DeleteMulti(x => x.ProductID == product.ID);

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            //this._unitOfWork.Commit();
        }
    }
}
