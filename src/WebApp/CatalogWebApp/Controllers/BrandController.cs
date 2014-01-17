using CatalogBusiness;
using CatalogWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatalogWebApp.Controllers
{
    public class BrandController : Controller
    {
        public ActionResult Index()
        {
            BrandBusiness brand = new BrandBusiness();
            return View(brand.GetAll());
        }

        [HttpGet]
        public ActionResult FormData(int? id)
        {
            BrandModel model = new BrandModel();

            if (id != null)
            {
                BrandBusiness currentBrand = new BrandBusiness();
                model.Brand = currentBrand.Get(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult FormData(BrandModel model)
        {
            try
            {
                BrandBusiness currentBrand = new BrandBusiness();
                currentBrand.SaveOrUpdate(model.Brand);
                return RedirectToAction("Index");
            }
            catch (ApplicationException appEx)
            {
                ViewBag.ErrorMessage = appEx.Message;
                return View();            
            }
        }
    }
}