using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using CatalogBusiness;
using CatalogBusiness.BusinessEntities;
using CatalogWebApp.Models;
using System;

namespace CatalogWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            CategoryBusiness c = new CategoryBusiness();
            IList<CategoryTreeViewModel> cats = GetCategoriesList(c.GetAll().Where(it => it.ParentCategory == null).ToList());
            return View(cats);
        }

        private IList<CategoryTreeViewModel> GetCategoriesList(List<Category> current)
        {
            IList<CategoryTreeViewModel> cats = new List<CategoryTreeViewModel>();
            CategoryBusiness c = new CategoryBusiness();
            foreach (var cat in current)
            {
                CategoryTreeViewModel item = new CategoryTreeViewModel() { Id = cat.Id, Name = cat.Name, Type = "Category", List = GetCategoriesList(c.GetAll().Where(i => i.ParentCategory != null && i.ParentCategory.Id == cat.Id).ToList()) };
                ProductBusiness pr = new ProductBusiness();
                foreach (Product p in pr.GetAll().Where(p => p.Categories.Select(i => i.Id).Contains(cat.Id)).ToList())
                    item.List.Add(new CategoryTreeViewModel() { Id = p.Id, Name = p.Name, Type = "Product", BrandName = p.Brand.Name });

                cats.Add(item);
            }
            return cats;
        }

        [HttpGet]
        public ActionResult FormData(int? id)
        {
            CategoryModel model = new CategoryModel();
            CategoryBusiness cBusiness = new CategoryBusiness();
            if (id != null)
            {
                model.Category = cBusiness.Get(id.Value);
            }
            GetAvailableCategories(id, model, cBusiness);
            return View(model);
        }

        private void GetAvailableCategories(int? id, CategoryModel model, CategoryBusiness cBusiness)
        {
            if (id != null && id != default(int))
            {
                foreach (Category item in cBusiness.GetAll().Where(it => !it.Id.Equals(id)).ToList<Category>())
                {
                    SelectListItem sli = new SelectListItem() { Value = item.Id.ToString(), Text = item.Name, Selected = (model.Category.ParentCategory != null && item.Id.Equals(model.Category.ParentCategory.Id)) };
                    model.AvailableParentCategories.Add(sli);
                }
            }
            else
            {
                foreach (Category item in cBusiness.GetAll())
                    model.AvailableParentCategories.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
        }

        [HttpPost]
        public ActionResult FormData(CategoryModel model)
        {
            CategoryBusiness cBusiness = new CategoryBusiness();

            try
            {
                if (model.Category.ParentCategory.Id != default(int))
                    model.Category.ParentCategory = cBusiness.Get(model.Category.ParentCategory.Id);
                else
                    model.Category.ParentCategory = null;
                cBusiness.SaveOrUpdate(model.Category);
                return RedirectToAction("Index");
            }
            catch (ApplicationException appEx)
            {
                ViewBag.ErrorMessage = appEx.Message;
                GetAvailableCategories(model.Category.Id, model, cBusiness);
                return View(model);
            }
        }

    }
}