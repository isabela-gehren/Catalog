using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogBusiness;
using CatalogBusiness.BusinessEntities;
using System.Collections.Generic;

namespace Tests.Integration
{
    [TestClass]
    public class ProductTests
    {
        string productName;
        string brandName;
        int brandId;
        string categoryName;
        int categoryId;

        [TestInitialize]
        public void Setup()
        {
            productName = "product_integrationtest";
            brandName = "productbrand_integrationtest";
            categoryName = "productcategory_integrationtest";            
        }

        [TestMethod]
        public void Create()
        {
            BrandBusiness b = new BrandBusiness();
            brandId = b.SaveOrUpdate(new Brand() { Name = brandName });

            CategoryBusiness c = new CategoryBusiness();
            categoryId = c.SaveOrUpdate(new Category() { Name = categoryName }); 
            
            ProductBusiness p = new ProductBusiness();
            Product product = new Product();
            product.Name = productName;
            product.Brand = b.GetByName(brandName).FirstOrDefault();
            product.Categories = new List<Category>() { c.GetByName(categoryName).FirstOrDefault() };
            Assert.AreNotEqual(p.SaveOrUpdate(product), default(int));
        }

        [TestMethod]
        public void Get()
        {
            ProductBusiness p = new ProductBusiness();
            Assert.AreNotEqual(p.GetByName(productName).Count, 0);
        }

        [TestMethod]
        public void GetAll()
        {
            ProductBusiness p = new ProductBusiness();
            Assert.AreNotEqual(p.GetAll().Count, 0);
        }

        [TestMethod]
        public void Delete()
        {
            ProductBusiness p = new ProductBusiness();
            Assert.IsTrue(p.Delete(p.GetByName(productName)[0]));

            BrandBusiness b = new BrandBusiness();
            b.Delete(b.GetByName(brandName).FirstOrDefault());

            CategoryBusiness c=new CategoryBusiness();
            c.Delete(c.GetByName(categoryName).FirstOrDefault());
        }
    }
}
