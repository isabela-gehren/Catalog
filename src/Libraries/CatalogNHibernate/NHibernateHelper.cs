using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace CatalogNHibernate
{
    public sealed class NHibernateHelper
    {
        private static ISessionFactory SessionFactory;

        private static void OpenSession()
        {
            Configuration configuration = new Configuration();
            //configuration.AddAssembly(Assembly.GetCallingAssembly());
            SessionFactory = configuration.Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            if (SessionFactory == null)
                NHibernateHelper.OpenSession();

            return SessionFactory.OpenSession();
        }

        public static void CloseSessionFactory()
        {
            if (SessionFactory != null)
                SessionFactory.Close();
        }
    }
}
