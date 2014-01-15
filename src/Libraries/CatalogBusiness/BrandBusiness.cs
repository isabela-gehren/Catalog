using System;
using System.Collections.Generic;
using CatalogDal;
using CatalogNHibernate;
using CatalogBusiness.BusinessEntities;

namespace CatalogBusiness
{
    public class BrandBusiness
    {
        public BrandBusiness() { }

        public Brand Get(int id)
        {
            IBrandDal dal = Factory.Resolve<CatalogDal.IBrandDal>();
            BrandVO vo = dal.Get(id);
            return new Brand(vo.Id, vo.Name);
        }

        public List<Brand> GetByName(string name)
        {
            List<Brand> lista = new List<Brand>();
            IBrandDal dal = Factory.Resolve<CatalogDal.IBrandDal>();
            foreach (BrandVO vo in dal.GetByName(name))
            {
                lista.Add(new Brand(vo.Id, vo.Name));
            }
            return lista;
        }

        public List<Brand> GetAll()
        {
            List<Brand> lista = new List<Brand>();
            IBrandDal dal = Factory.Resolve<CatalogDal.IBrandDal>();
            foreach (BrandVO vo in dal.GetAll())
            {
                lista.Add(new Brand(vo.Id, vo.Name));
            }
            return lista;
        }

        public int SaveOrUpdate(Brand brand)
        {
            try
            {
                IBrandDal dal = Factory.Resolve<CatalogDal.IBrandDal>();
                BrandVO vo;
                if (brand.Id != default(int))
                    vo = dal.Get(brand.Id);
                else vo = new BrandVO();
                vo.Name = brand.Name;
                dal.SaveOrUpdate(vo);
                return vo.Id;
            }
            catch (Exception) { throw; }
        }

        public bool Delete(Brand brand)
        {
            try
            {
                BrandVO vo = new BrandVO();
                vo.Id = brand.Id;
                vo.Name = brand.Name;
                IBrandDal dal = Factory.Resolve<CatalogDal.IBrandDal>();
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
