using System;
using System.Linq;
using System.Collections.Generic;
using CatalogBusiness.BusinessEntities;
using CatalogDal;
using CatalogNHibernate;

namespace CatalogBusiness
{
    public class ProductBusiness
    {
        private IProductDal dal;
        public ProductBusiness()
        {
            dal = Factory.Get().Resolve<CatalogDal.IProductDal>();
        }

        public Product Get(int id)
        {
            ProductVO vo = dal.Get(id);
            return new Product(vo.Id, vo.Name, vo.Categories.ToList(), vo.Brand);
        }

        public List<Product> GetByName(string name)
        {
            List<Product> lista = new List<Product>();
            foreach (ProductVO vo in dal.GetByName(name))
            {
                lista.Add(new Product(vo.Id, vo.Name, vo.Categories.ToList(), vo.Brand));
            }
            return lista;
        }

        public List<Product> GetAll()
        {
            List<Product> lista = new List<Product>();
            foreach (ProductVO vo in dal.GetAll())
            {
                lista.Add(new Product(vo.Id, vo.Name, vo.Categories.ToList(), vo.Brand));
            }
            return lista;
        }

        public int SaveOrUpdate(Product product)
        {
            if (dal.GetByName(product.Name).Count > 0)
                throw new ApplicationException(string.Format("Já existe um produto cadastrado com o nome '{0}'", product.Name));

            try
            {
                ProductVO vo = PopulateVO(product);
                dal.SaveOrUpdate(vo);
                return vo.Id;
            }
            catch (Exception) { throw; }
        }

        private ProductVO PopulateVO(Product product)
        {
            ProductVO vo;
            if (product.Id != default(int))
                vo = dal.Get(product.Id);
            else vo = new ProductVO();
            vo.Name = product.Name;
            List<CategoryVO> categoriesVO = new List<CategoryVO>();

            foreach (Category current in product.Categories)
            {
                CategoryVO catVO = new CategoryVO();
                catVO.Id = current.Id;
                catVO.Name = current.Name;
                if(current.ParentCategory != null)
                {
                    catVO.ParentCategory = new CategoryVO { Id = current.ParentCategory.Id };
                }
                categoriesVO.Add(catVO);
            }
            vo.Categories = categoriesVO;
            vo.Brand = new BrandVO() { Id = product.Brand.Id, Name = product.Brand.Name };
            return vo;
        }

        public bool Delete(Product product)
        {
            try
            {
                ProductVO vo = PopulateVO(product);
                dal.Delete(vo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
