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
            Brand brand = new Brand();
            return View(brand.GetAll());
        }

        [HttpGet]
        public ActionResult FormData(int? id)
        {
            BrandModel model = new BrandModel();

            if (id != null)
            {
                Brand currentBrand = new Brand();
                model.Brand = currentBrand.Get(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult FormData(BrandModel model)
        {
            Brand currentBrand = new Brand();
            currentBrand.SaveOrUpdate(model.Brand);
            return RedirectToAction("Index");
        }
    }
}