using CatalogNHibernate;
using System.Collections.Generic;

namespace CatalogBusiness.BusinessEntities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }

        public Category() { }

        internal Category(CategoryVO vo)
        {            
            this.Id = vo.Id;
            this.Name = vo.Name;

            if (vo.ParentCategory != null)
            {
                this.ParentCategory = new Category(vo.ParentCategory);
            }

        }
    }
}
