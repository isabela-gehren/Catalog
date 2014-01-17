using CatalogBusiness;
using CatalogDal;

namespace CatalogTests.UnitTest.Mocks
{
    public class BrandMock : BrandBusiness
    {
        public static void SetMock(IBrandDal mock)
        {
            dal = mock;
        }
    }
}
