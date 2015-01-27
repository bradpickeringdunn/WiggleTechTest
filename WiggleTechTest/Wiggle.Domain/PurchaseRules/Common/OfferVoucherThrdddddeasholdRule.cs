using Backbone.ErrorHandling;
using Backbone.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules.Common
{
    /// <summary>
    /// Rules governing the meeting of Offer Voucher Threasholds
    /// </summary>
    internal class OfferVoucherThreasholdRule
    {
        //TODO move to database / config
        private IEnumerable<ProductCategoryEnum> ExcludedProducts = new List<ProductCategoryEnum>()
        {
            ProductCategoryEnum.GiftVoucher
        };

        private ShoppingBasketDto Basket {get;set;}

        /// <summary>
        /// Determins f any products should not be evaluated in the conditon and executes the evaluation of basket toatl and offer threashold.
        /// </summary>
        internal ShoppingBasketDto Validate(ShoppingBasketDto basket)
        {
            Guardian.ArgumentNotNull(basket, "basket");

            this.Basket = basket;

            CheckBasketTotalMeetsThreashold();

            return this.Basket;
        }

        private void CheckBasketTotalMeetsThreashold()
        {
            var tempBasket = CreateTempBasket();
            tempBasket = RemoveExcludedProductsFrom(tempBasket);
            tempBasket.CalculateTotal();

            if (tempBasket.Total < Basket.OfferVoucher.Threashold)
            {
                Basket.Notifications.Add(
                   new Notification(
 new Error("You have not reached the spend threshold for voucher YYY-YYY. Spend another £{0} to receive £{1} discount from your basket total.".FormatLiteralArguments(0, 25))));
            }
        }

        private ShoppingBasketDto CreateTempBasket()
        {
            var productList = new List<ProductDto>();
            productList.AddRange(this.Basket.Products);
            
            var tempBasket = new ShoppingBasketDto(){
                Products = productList
            };

            return tempBasket;
        }

        private ShoppingBasketDto RemoveExcludedProductsFrom(ShoppingBasketDto tempBasket)
        {
            this.Basket.Products.ForEach(p =>
            {
                if (ExcludedProducts.Contains(p.Category))
                {
                    tempBasket.Products.Remove(p);
                }
            });

            return tempBasket;
        }
    }
}
