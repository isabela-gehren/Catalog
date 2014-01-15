using CatalogDal;
using System;

namespace CatalogBusiness
{
    internal class FactoryNHibernate : IFactory
    {
        public IDataStore Resolve<IDataStore>()
        {
            switch (typeof(IDataStore).Name)
            {
                case "IBrandDal":
                    return (IDataStore)(object)new BrandDal();
                case "IProductDal":
                    return (IDataStore)(object)new ProductDal();
                case "ICategoryDal":
                    return (IDataStore)(object)new CategoryDal();
            }
            throw new ApplicationException("DataStore " + typeof(IDataStore).Name + " não está configurado no Factory!");
        }
    }

}


