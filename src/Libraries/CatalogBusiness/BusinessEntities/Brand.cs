using CatalogNHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBusiness.BusinessEntities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Brand() { }
        internal Brand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        internal Brand(BrandVO brand)
        {
            this.Id = brand.Id;
            this.Name = brand.Name;
        }
    }

}
