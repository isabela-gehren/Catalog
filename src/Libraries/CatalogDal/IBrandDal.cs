using CatalogNHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDal
{
    public interface IBrandDal
    {
        BrandVO Get(int id);
        List<BrandVO> GetByName(string name);
        int SaveOrUpdate(BrandVO vo);
        void Delete(BrandVO vo);
    }
}
