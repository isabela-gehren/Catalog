using System.Collections.Generic;
using System.Web.Mvc;
using CatalogBusiness.BusinessEntities;

namespace CatalogWebApp.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            this.AvailableParentCategories = new List<SelectListItem>();
        }
        public Category Category { get; set; }
        public List<SelectListItem> AvailableParentCategories { get; set; }
    }
}