using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogBusiness;
using CatalogBusiness.BusinessEntities;

namespace Tests.Integration
{
    [TestClass]
    public class BrandTests
    {
        private string brandName;
        private string newBrandName;

        [TestInitialize]
        public void SetUp()
        {
            brandName = "brand_integrationtest";
            newBrandName = "newbrand_integrationtest";
        }

        [TestMethod]
        public void CreateBrand()
        {
            BrandBusiness b = new BrandBusiness();
            Assert.AreNotEqual(b.SaveOrUpdate(new Brand() { Name = brandName }), default(int));
        }

        [TestMethod]
        public void GetBrand()
        {
            BrandBusiness b = new BrandBusiness();
            Assert.IsNotNull(b.GetByName(brandName).FirstOrDefault().Id);
        }

        [TestMethod]
        public void Update()
        {
            BrandBusiness b = new BrandBusiness();
            Brand vo = b.GetByName(brandName).FirstOrDefault();
            vo.Name = newBrandName;
            Assert.AreEqual(vo.Id, b.SaveOrUpdate(vo));
        }

        [TestMethod]
        public void Delete()
        {
            BrandBusiness b = new BrandBusiness();
            Brand vo = b.GetByName(newBrandName).FirstOrDefault();
            Assert.IsTrue(b.Delete(vo));
        }
    }
}
