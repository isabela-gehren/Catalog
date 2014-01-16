using CatalogBusiness.BusinessEntities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CatalogWebApp.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            AvailableCategories = new List<Category>();
            AvailableBrands = new List<Brand>();
            Categories = new List<SelectListItem>();
        }
        public List<Category> AvailableCategories;
        public List<SelectListItem> Categories;
        public List<Brand> AvailableBrands;
        public Product Product { get; set; }
    }
}