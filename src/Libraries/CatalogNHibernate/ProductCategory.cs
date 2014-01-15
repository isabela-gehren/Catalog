using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogNHibernate
{
    public class ProductCategory
    {
        private int productId;
        private int categoryId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
    }
}
