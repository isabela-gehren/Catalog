using System;
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
            Assert.IsNotNull(b.SaveOrUpdate(new Brand() { Name = brandName }));
        }

        [TestMethod]
        public void GetBrand()
        {
            BrandBusiness b = new BrandBusiness();
            Assert.IsNotNull(b.GetByName(brandName)[0].Id);
        }

        [TestMethod]
        public void Update()
        {
            BrandBusiness b = new BrandBusiness();
            Brand eBrand = b.GetByName(brandName)[0];
            eBrand.Name = newBrandName;
            Assert.AreEqual(eBrand.Id, b.SaveOrUpdate(eBrand));
        }

        [TestMethod]
        public void Delete()
        {
            BrandBusiness b = new BrandBusiness();
            Brand eBrand = b.GetByName(newBrandName)[0];
            Assert.IsTrue(b.Delete(eBrand));
        }
    }
}
