using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Models;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;

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
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWord)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWord;
        }
        public Product Add(Product product)
        {
            return this._productRepository.Add(product);
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
        }
    }
}
