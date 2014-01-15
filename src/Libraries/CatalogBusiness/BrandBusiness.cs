using System;
using System.Collections.Generic;
using CatalogDal;
using CatalogNHibernate;
using CatalogBusiness.BusinessEntities;

namespace CatalogBusiness
{
    public class BrandBusiness
    {
        private IBrandDal dal;
        public BrandBusiness()
        {
            dal = Factory.Get().Resolve<CatalogDal.IBrandDal>();
        }

        public Brand Get(int id)
        {
            BrandVO vo = dal.Get(id);
            return new Brand(vo.Id, vo.Name);
        }

        public List<Brand> GetByName(string name)
        {
            List<Brand> lista = new List<Brand>();
            foreach (BrandVO vo in dal.GetByName(name))
            {
                lista.Add(new Brand(vo.Id, vo.Name));
            }
            return lista;
        }

        public List<Brand> GetAll()
        {
            List<Brand> lista = new List<Brand>();
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
                BrandVO vo = PopulateVO(brand);
                dal.SaveOrUpdate(vo);
                return vo.Id;
            }
            catch (Exception) { throw; }
        }

        public bool Delete(Brand brand)
        {
            try
            {
                BrandVO vo = PopulateVO(brand);
                dal.Delete(vo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private BrandVO PopulateVO(Brand brand)
        {
            BrandVO vo = new BrandVO();
            vo.Id = brand.Id;
            vo.Name = brand.Name;
            return vo;
        }
    }
}
