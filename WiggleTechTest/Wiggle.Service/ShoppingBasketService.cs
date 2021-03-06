﻿using System;
using System.Linq;
using Backbone.ErrorHandling;
using Backbone.Logging;
using Backbone.Repository;
using Backbone.Utilities;
using Wiggle.Domain;
using Wiggle.Service.Api.Contract;
using Wiggle.Service.Models.ShoppingBasket.Request;
using Wiggle.Service.Models.ShoppingBasket.Result;

namespace Wiggle.Service
{
    public class ShoppingBasketService : IShoppingBasketServiceContract, IDisposable
    {
        public IRepository Repository { get; set; }
        public ILogger Logger { get; set; }
        public NotificationCollection Notifications = new NotificationCollection();

        public ShoppingBasketService(ILogger logger)
        {
            Logger = logger;
        }
        
        public CalculateBasketTotalResult CalculateBasketTotal(CalculateBasketTotalRequest request)
        {
            Guardian.ArgumentNotNull(request, "request");
            Guardian.ArgumentNotNull(request.Basket, "request.Basket");
            Guardian.ArgumentNotNull(request.Basket.Products, "request.Basket.Products");

            var basket = request.Basket;

            if (!basket.Products.Any())
            {
                basket.Notifications.Add("This basket is empty.");
            }

            if (basket.OfferVoucher.IsNotNull() && !basket.Notifications.HasErrors)
            {
                var shoppingBasketOffer = new ShoppingBasketOffer();
                basket = shoppingBasketOffer.ValidateOffForBasket(basket);

                if (!basket.Notifications.HasErrors)
                {
                    basket = shoppingBasketOffer.ApplyOfferVoucher(basket);
                }
            }

            if (basket.GiftVouchers.IsNotNull() && basket.GiftVouchers.Any())
            {
                basket = new CalculateBasket().ApplyGiftVouchers(basket);
            }

            return new CalculateBasketTotalResult()
            {
                Basket = basket
            };
        }

        public void Dispose()
        {
        }
    }
}
