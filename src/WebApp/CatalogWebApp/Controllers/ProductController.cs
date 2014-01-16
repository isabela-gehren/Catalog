using CatalogBusiness;
using CatalogBusiness.BusinessEntities;
using CatalogWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatalogWebApp.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult FormData(int? id)
        {
            ProductModel model = new ProductModel();
            if (id != null)
            {
                ProductBusiness pBusiness = new ProductBusiness();
                model.Product = pBusiness.Get(id.Value);
            }
            CategoryBusiness cBusiness = new CategoryBusiness();
            model.AvailableCategories = cBusiness.GetAll();
            foreach (Category current in cBusiness.GetAll())
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = current.Id.ToString();
                listItem.Text = current.Name;
                listItem.Selected = id != null && model.Product.Categories.Select(i=>i.Id).Contains(current.Id);
                model.Categories.Add(listItem);
            }

            BrandBusiness bBusiness = new BrandBusiness();
            model.AvailableBrands = bBusiness.GetAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult FormData(ProductModel model, FormCollection formCollection)
        {
            CategoryBusiness cBusiness = new CategoryBusiness();
            foreach (string categoryId in formCollection["Produto_CategoryIds"].Split(','))
            {
                model.Product.Categories.Add(cBusiness.Get(Convert.ToInt32(categoryId)));
            }
            BrandBusiness bBusiness = new BrandBusiness();
            model.Product.Brand = bBusiness.Get(model.Product.Brand.Id);
            ProductBusiness pBusiness = new ProductBusiness();
            pBusiness.SaveOrUpdate(model.Product);
            return RedirectToAction("Index", "Category");
        }
    }
}