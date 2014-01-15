using CatalogBusiness;
using CatalogBusiness.BusinessEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Integration
{
    [TestClass]
    public class CategoryTests
    {
        private string CategoryNamePai;
        private string CategoryNameFilha;
        private string NewCategoryNamePai;

        [TestInitialize]
        public void SetUp()
        {
            CategoryNamePai = "NomePai";
            CategoryNameFilha = "NomeFilha";
            NewCategoryNamePai = "NewNomePai";
        }

        [TestMethod]
        public void CreatePai()
        {
            CategoryBusiness b = new CategoryBusiness();
            Assert.AreNotEqual(b.SaveOrUpdate(new Category() { Name = CategoryNamePai }), default(int));
        }

        [TestMethod]
        public void CreateFilha()
        {
            CategoryBusiness b = new CategoryBusiness();
            Category category = new Category() { Name = CategoryNameFilha, ParentCategory = b.GetByName(CategoryNamePai).FirstOrDefault() };
            Assert.AreNotEqual(b.SaveOrUpdate(category), default(int));
        }

        [TestMethod]
        public void GetFilha()
        {
            CategoryBusiness b = new CategoryBusiness();
            Assert.AreNotEqual(b.GetByName(CategoryNameFilha), 0);
        }

        [TestMethod]
        public void Update()
        {
            CategoryBusiness b = new CategoryBusiness();
            Category category = b.GetByName(CategoryNamePai).FirstOrDefault();
            category.Name = NewCategoryNamePai;
            Assert.AreEqual(b.SaveOrUpdate(category), category.Id);
        }

        [TestMethod]
        public void Delete()
        {
            CategoryBusiness b = new CategoryBusiness();
            Assert.IsTrue(b.Delete(b.GetByName(CategoryNameFilha).FirstOrDefault()));
            Assert.IsTrue(b.Delete(b.GetByName(NewCategoryNamePai).FirstOrDefault()));
        }
    }
}
