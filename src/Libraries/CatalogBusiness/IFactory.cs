
namespace CatalogBusiness
{
    public interface IFactory
    {
        IDataStore Resolve<IDataStore>();
    }
}
