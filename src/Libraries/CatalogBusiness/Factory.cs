using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;


namespace CatalogBusiness
{
    internal class Factory 
    {
        private static IFactory _factory = null;

        public static IFactory Get()
        {
            if (_factory == null)
            {
                UnityConfigurationSection unityConfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                ContainerElement containerElement = unityConfig.Containers["DataStore.Factory"];

                UnityContainer container = new UnityContainer();
                unityConfig.Configure(container, containerElement.Name);

                IFactory factory = (IFactory)container.Resolve<IFactory>();
                if (factory == null) throw new ApplicationException("O factory IFactory não está configurado!");
                _factory = factory;
            }
            return _factory;
        }
    }
}
