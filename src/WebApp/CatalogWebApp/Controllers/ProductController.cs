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
            GetCategories(id, model);

            GetBrands(model);
            return View(model);
        }

        private void GetBrands(ProductModel model)
        {
            BrandBusiness bBusiness = new BrandBusiness();
            model.AvailableBrands = bBusiness.GetAll();
        }

        private void GetCategories(int? id, ProductModel model)
        {
            CategoryBusiness cBusiness = new CategoryBusiness();

            foreach (Category current in cBusiness.GetAll())
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = current.Id.ToString();
                listItem.Text = current.Name;
                listItem.Selected = id != null && model.Product.Categories.Select(i => i.Id).Contains(current.Id);
                model.Categories.Add(listItem);
            }
        }

        [HttpPost]
        public ActionResult FormData(ProductModel model, FormCollection formCollection)
        {
            try
            {
                BrandBusiness bBusiness = new BrandBusiness();
                CategoryBusiness cBusiness = new CategoryBusiness();
                if (formCollection["Produto_CategoryIds"] == null)
                {
                    return FormDataReturnError("Selecione uma categoria", model);
                }
                foreach (string categoryId in formCollection["Produto_CategoryIds"].Split(','))
                {
                    model.Product.Categories.Add(cBusiness.Get(Convert.ToInt32(categoryId)));
                }

                model.Product.Brand = bBusiness.Get(model.Product.Brand.Id);
                ProductBusiness pBusiness = new ProductBusiness();
                pBusiness.SaveOrUpdate(model.Product);
                return RedirectToAction("Index", "Category");
            }
            catch (ApplicationException appEx)
            {
                return FormDataReturnError(appEx.Message, model);
            }
        }

        private ActionResult FormDataReturnError(string mensagem, ProductModel model)
        {
            ViewBag.ErrorMessage = mensagem;
            GetCategories(model.Product.Id, model);
            GetBrands(model);
            return View(model);
        }
    }
}