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

            var result = new CalculateBasketTotalResult();
          
            var basket = request.Basket;

            var basketTotal = basket.GetCostOfProducts();
            //var total = CalculateBasketTotal(basket, validOffer);

            if (!basket.Products.Any())
            {
                Notifications.Add("This basket is empty.");
            }

            if (basket.OfferVoucher.IsNotNull())
            {
                result = new ValidateOfferVoucher().ApplyOfferVoucher(basket);
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

        private decimal CalculateBasketTotal(Models.ShoppingBasket.ShoppingBasketDto basket, bool validOffer)
        {
            decimal total = 0.0m;

            foreach (var product in basket.Products)
            {
                total += product.Price;
            }

            return total;

        }

        

        public void Dispose()
        {
        }
    }
}
