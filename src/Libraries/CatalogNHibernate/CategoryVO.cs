using System;
using System.Collections.Generic;

namespace CatalogNHibernate
{
    public class CategoryVO
    {
        private int id;
        private string name;
        private CategoryVO parentCategory;

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

        public virtual CategoryVO ParentCategory
        {
            get { return parentCategory; }
            set { parentCategory = value; }
        }
    }
}
