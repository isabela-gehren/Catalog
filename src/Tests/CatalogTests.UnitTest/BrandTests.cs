using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogDal;
using Moq;
using CatalogNHibernate;
using FizzWare.NBuilder;
using CatalogBusiness.BusinessEntities;
using CatalogBusiness;
using System.Collections.Generic;
using CatalogTests.UnitTest.Mocks;

namespace CatalogTests.UnitTest
{
    [TestClass]
    public class BrandTests
    {
        [TestMethod]
        public void Get()
        {
            Mock<IBrandDal> brandDalMock = new Mock<IBrandDal>();
            BrandVO retorno = new BrandVO() { Id = 1, Name = "Marca 1" };
            brandDalMock.Setup(a => a.Get(1)).Returns(retorno);

            BrandBusiness brandBusiness = new BrandBusiness();
            BrandMock.SetMock(brandDalMock.Object);
            Assert.IsNotNull(brandBusiness.Get(1));
        }

        [TestMethod]
        public void GetAll()
        {
            Mock<IBrandDal> brandDalMock = new Mock<IBrandDal>();
            List<BrandVO> retorno = new List<BrandVO>();
            retorno.Add(new BrandVO() { Id = 1, Name = "Marca 1" });
            brandDalMock.Setup(a => a.GetAll()).Returns(retorno);

            BrandBusiness brandBusiness = new BrandBusiness();
            BrandMock.SetMock(brandDalMock.Object);
            Assert.AreEqual(brandBusiness.GetAll().Count, 1);
        }

        [TestMethod]
        public void GetByName()
        {
            Mock<IBrandDal> brandDalMock = new Mock<IBrandDal>();
            List<BrandVO> retorno = new List<BrandVO>();
            retorno.Add(new BrandVO() { Id = 1, Name = "Marca 1" });
            brandDalMock.Setup(a => a.GetByName("Marca 1")).Returns(retorno);

            BrandBusiness brandBusiness = new BrandBusiness();
            BrandMock.SetMock(brandDalMock.Object);
            Assert.AreEqual(brandBusiness.GetByName("Marca 1").Count, 1);
            Assert.AreEqual(brandBusiness.GetByName("Marca 1").First().Name, "Marca 1");
        }

        [TestMethod]
        public void Delete()
        {
            Mock<IBrandDal> brandDalMock = new Mock<IBrandDal>();
            brandDalMock.Setup(a => a.Delete(new BrandVO() { Id = 1, Name = "Marca 1" }));

            BrandBusiness brandBusiness = new BrandBusiness();
            BrandMock.SetMock(brandDalMock.Object);
            Assert.IsNotInstanceOfType(brandBusiness.Delete(new Brand() { Id = 1, Name = "Marca 1" }), typeof(Exception));
        }

        [TestMethod]
        public void Insert()
        {
            Mock<IBrandDal> brandDalMock = new Mock<IBrandDal>();
            brandDalMock.Setup(a => a.SaveOrUpdate(new BrandVO() { Id = 1, Name = "Marca 1" }));

            BrandBusiness brandBusiness = new BrandBusiness();
            BrandMock.SetMock(brandDalMock.Object);
            Assert.AreEqual(brandBusiness.SaveOrUpdate(new Brand() { Id = 1, Name = "Marca 1" }), 1);
        }
    }
}
