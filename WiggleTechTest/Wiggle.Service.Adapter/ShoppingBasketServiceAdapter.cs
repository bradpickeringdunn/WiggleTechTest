using System;
using Backbone.Logging;
using Backbone.Repository;
using Wiggle.Service.Api.Contract;
using Wiggle.Service.Models.ShoppingBasket.Request;
using Wiggle.Service.Models.ShoppingBasket.Result;

namespace Wiggle.Service.Adapter
{
    public class ShoppingBasketServiceAdapter : IShoppingBasketServiceContract
    {
        private ILogger Logger { get; set; }
        IShoppingBasketServiceContract ShoppingBasketService { get; set; }
     
        public ShoppingBasketServiceAdapter(ILogger logger, IShoppingBasketServiceContract shoppingBasketService)
        {
            Logger = logger;
            ShoppingBasketService = shoppingBasketService;
        }

        public CalculateBasketTotalResult CalculateBasketTotal(CalculateBasketTotalRequest request)
        {
            var result = new CalculateBasketTotalResult();

            try
            {
                result = ShoppingBasketService.CalculateBasketTotal(request);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                result.Basket.Notifications.Add("General service exception");
            }

            return result;
        }
    }
}
