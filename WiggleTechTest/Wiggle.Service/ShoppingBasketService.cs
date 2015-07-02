using System;
using System.Linq;
using Backbone.ErrorHandling;
using Backbone.Logging;
using Backbone.Repository;
using Backbone.Utilities;
using Wiggle.Domain;
using Wiggle.Service.Api.Contract;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket.Request;
using Wiggle.Service.Models.ShoppingBasket.Result;

namespace Wiggle.Service
{
    public class ShoppingBasketService : IShoppingBasketServiceContract, IDisposable
    {
        public IRepository Repository { get; set; }
        public ILogger Logger { get; set; }
        public NotificationCollection Notifications = new NotificationCollection();

        public ShoppingBasketService(IRepository repo, ILogger logger)
        {
            Logger = logger;
            Repository = Repository;
        }
        
        public CalculateBasketTotalResult CalculateBasketTotal(CalculateBasketTotalRequest request)
        {
            Guardian.ArgumentNotNull(request, "request");
            Guardian.ArgumentNotNull(request.Basket, "request.Basket");
            Guardian.ArgumentNotNull(request.Basket.Products, "request.Basket.Products");

            var basket = request.Basket;
            var result = new CalculateBasketTotalResult();
            result.Total = basket.Total;

            if (!basket.Products.Any())
            {
                result.Notifications.Add("This basket is empty.");
            }

            if (basket.OfferVoucher.IsNotNull() && !result.Notifications.HasErrors)
            {
                result = new CalculateShoppingBasketTotal().ApplyOfferVoucher(basket);
            }

            if (basket.GiftVouchers.IsNotNull() && basket.GiftVouchers.Any())
            {
                foreach (var giftVoucher in basket.GiftVouchers)
                {
                    result.Total -= giftVoucher.Value;
                }
            }          

            return result;
        }

        public void Dispose()
        {
        }
    }
}
