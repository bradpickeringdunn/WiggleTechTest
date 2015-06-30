using Backbone.Repository;
using Microsoft.Practices.Unity;
using Unity.Wcf;
using Unity;
using Wiggle.Repository;
using Wiggle.Service.Adapter;
using Wiggle.Service.Api.Contract;
using Backbone.Logging;

namespace Wiggle.Service.Host
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {

			// register all your components with the container here
             container.RegisterType<IShoppingBasketServiceContract, ShoppingBasketServiceAdapter>();
             container.RegisterType<IRepository, Repo>();
             container.RegisterType<IOfferVoucherThreasholdRule, OfferVoucherThreasholdRule>();
             container.RegisterType<IProductPurchaeRules, ProductPurchaeRules>();
             container.RegisterType<IShoppingBasketOfferVoucherRules, ShoppingBasketOfferVoucherRules>();
             container.RegisterType<IShoppingBasketProducts, ShoppingBasketProducts>();
             container.RegisterType<IShoppingBasketServiceContract, ShoppingBasketServiceAdapter>();
             container.RegisterType<ILogger, DebugLogger>();
             container.RegisterType<IProductServiceContract, ProductServiceAdapter>();
            
        }
    }    
}