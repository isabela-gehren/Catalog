using System.Collections.Generic;
using CatalogNHibernate;
using CatalogBusiness.BusinessEntities;

namespace CatalogBusiness.BusinessEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public List<Category> Categories { get; set; }

        public Product()
        {
            this.Categories = new List<Category>();
        }
        internal Product(int id, string name, List<CategoryVO> categories, BrandVO brand)
        {
            this.Id = id;
            this.Name = name;
            this.Brand = new Brand(brand);
            this.Categories = new List<Category>();
            foreach (CategoryVO current in categories)
            {
                this.Categories.Add(new Category(current));
            }
        }

    }
}
