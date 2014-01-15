using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDal
{
    public interface IGenericDal<T>
    {
        T Get(int id);
        List<T> GetByName(string name);
        List<T> GetAll();
        T SaveOrUpdate(T vo);
        void Delete(T vo);
    }
}
