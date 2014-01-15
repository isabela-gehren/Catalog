using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogNHibernate
{
    public class CategoryVO
    {
        private int id;
        private string name;
        private int parentCategoryId;

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
        public int ParentCategoryId
        {
            get { return parentCategoryId; }
            set { parentCategoryId = value; }
        }
    }
}
