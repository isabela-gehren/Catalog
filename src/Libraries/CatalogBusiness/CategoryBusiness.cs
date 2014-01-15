using System;
using System.Collections.Generic;
using CatalogNHibernate;
using CatalogDal;
using CatalogBusiness.BusinessEntities;

namespace CatalogBusiness
{
    public class CategoryBusiness
    {
        private ICategoryDal dal;
        public CategoryBusiness()
        {
            dal = Factory.Get().Resolve<CatalogDal.ICategoryDal>();
        }
        
        public Category Get(int id)
        {
           CategoryVO vo = dal.Get(id);
           return new Category(vo.ParentCategory);
        }
        public List<Category> GetByName(string name)
        {
            List<Category> lista = new List<Category>();
            foreach (CategoryVO vo in dal.GetByName(name))
            {
                lista.Add(new Category(vo));
            }
            return lista;
        }
        public List<Category> GetAll()
        {
            List<Category> lista = new List<Category>();
            foreach (CategoryVO vo in dal.GetAll())
            {
                lista.Add(new Category(vo.ParentCategory));
            }
            return lista;
        }

        public int SaveOrUpdate(Category category)
        {
            try
            {
                CategoryVO vo = new CategoryVO();
                vo.Id = category.Id;
                vo.Name = category.Name;

                if (category.ParentCategory != null)
                {
                    vo.ParentCategory = new CategoryVO();
                    vo.ParentCategory.Id = category.ParentCategory.Id;
                }
                dal.SaveOrUpdate(vo);
                return vo.Id;
            }
            catch (Exception) { throw; }
        }
        public bool Delete(Category category)
        {
            try
            {
                CategoryVO vo = new CategoryVO();
                vo.Id = category.Id;
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

