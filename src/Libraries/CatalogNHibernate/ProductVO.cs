using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogNHibernate
{
    public class ProductVO
    {
        private int id;
        private string name;
        private BrandVO brand;
        private IList<CategoryVO> categories;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual BrandVO Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public virtual IList<CategoryVO> Categories
        {
            get { return categories; }
            set { categories = value; }
        }
    }
}
