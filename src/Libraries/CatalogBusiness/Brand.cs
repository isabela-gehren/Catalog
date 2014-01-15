using CatalogDal;
using CatalogNHibernate;
using System;
using System.Collections.Generic;

namespace CatalogBusiness
{
    public class Brand
    {
        public int Id;
        public string Name;

        public Brand() { }
        private Brand(BrandVO vo)
        {
            this.Id = vo.Id;
            this.Name = vo.Name;
        }

        public Brand Get(int id)
        {
            IBrandDal dal = Factory.Resolve<CatalogDal.IBrandDal>();
            return new Brand(dal.Get(id));
        }

        public List<Brand> GetByName(string name)
        {
            List<Brand> lista = new List<Brand>();
            IBrandDal dal = Factory.Resolve<CatalogDal.IBrandDal>();
            foreach (BrandVO vo in dal.GetByName(name))
            {
                lista.Add(new Brand(vo));
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
