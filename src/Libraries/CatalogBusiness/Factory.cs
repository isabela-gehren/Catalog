using CatalogDal;
using System;

namespace CatalogBusiness
{
    public class Factory
    {
        public static IDataStore Resolve<IDataStore>()
        {
            switch (typeof(IDataStore).Name)
            {
                case "IBrandDal":
                    return (IDataStore)(object)new BrandDal();
            }
            throw new ApplicationException("DataStore " + typeof(IDataStore).Name + " não está configurado no Factory!");
        }
    }

}


