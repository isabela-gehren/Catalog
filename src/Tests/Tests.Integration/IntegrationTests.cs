using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogBusiness;

namespace Tests.Integration
{
    [TestClass]
    public class IntegrationTests
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
            Brand b = new Brand();
            Assert.IsNotNull(b.SaveOrUpdate(new Brand() { Name = brandName }));
        }

        [TestMethod]
        public void GetBrand()
        {
            Brand b = new Brand();
            Assert.IsNotNull(b.GetByName(brandName)[0].Id);
        }

        [TestMethod]
        public void Update()
        {
            Brand b = new Brand();
            Brand brand = b.GetByName(brandName)[0];
            brand.Name = newBrandName;
            Assert.AreEqual(brand.Id, b.SaveOrUpdate(brand));
        }

        [TestMethod]
        public void Delete()
        {
            Brand b = new Brand();
            Brand brand = b.GetByName(newBrandName)[0];
            Assert.IsTrue(b.Delete(brand));
        }
    }
}
