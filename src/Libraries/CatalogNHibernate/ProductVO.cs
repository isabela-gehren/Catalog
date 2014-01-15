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
        private int brandId;
        private List<CategoryVO> categories;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int BrandId
        {
            get { return brandId; }
            set { brandId = value; }
        }

        public List<CategoryVO> Categories
        {
            get
            {
                if (categories == null)
                    categories = new List<CategoryVO>();
                return categories;
            }
            set
            {
                categories = value;
            }
        }
    }
}
