using Backbone.Logging;
using Microsoft.Practices.Unity;
using Unity.Wcf;
using Wiggle.Service.Adapter;
using Wiggle.Service.Api.Contract;

namespace Wiggle.Service.Host
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {

			// register all your components with the container here
            container.RegisterType<IShoppingBasketServiceContract, ShoppingBasketServiceAdapter>();
            container.RegisterType<IShoppingBasketServiceContract, ShoppingBasketServiceAdapter>();
            container.RegisterType<ILogger, DebugLogger>();
            
        }
    }    
}