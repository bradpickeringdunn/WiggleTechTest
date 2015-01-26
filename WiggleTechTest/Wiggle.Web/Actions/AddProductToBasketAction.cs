using Backbone.ErrorHandling;
using Backbone.Repository;
using Backbone.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.ShoppingBasket;
using Wiggle.Web.Api.ViewModels;

namespace Wiggle.Web.Api.Actions
{
    public class AddProductToCartAction<T>where T:class
    {
        private IRepository Repository { get; set; }
        private IShoppingBasketProducts BasketProducts { get; set; }

        public AddProductToCartAction(IShoppingBasketProducts shoppingBasketProducts, IRepository repository)
        {
            this.Repository = repository;
            this.BasketProducts = shoppingBasketProducts;
        }

        public Func<ShoppingBasketViewModel, T> OnComplete { get; set; }

        public T Execute(ShoppingBasketDto basket, ProductDto product)
        {
            Guardian.ArgumentNotNull(basket, "ShoppingBasketDto");

            if (basket.Notifications.HasErrors)
            {
                basket.Notifications = new NotificationCollection();
            }

            basket = this.BasketProducts.AddProduct(basket, product);

            var model = new ShoppingBasketViewModel(){
                ShoppingBasket = basket
            };

            return OnComplete(model);
        }
    }
}