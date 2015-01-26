using Backbone.ErrorHandling;
using Backbone.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Localization;

namespace Wiggle.Domain.PurchaseRules.Common
{
    //TODO: move to database
    internal class OfferVoucherThreasholdRule : IOfferVoucherThreasholdRule
    {
        private IEnumerable<ProductCategoryEnum> ExcludedProducts = new List<ProductCategoryEnum>()
        {
            ProductCategoryEnum.GiftVoucher
        };

        private ShoppingBasketDto Basket { get; set; }

        /// <summary>
        /// Determins f any products should not be evaluated in the conditon and executes the evaluation of basket toatl and offer threashold.
        /// </summary>
        public ShoppingBasketDto Validate(ShoppingBasketDto basket)
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
                double difference = Basket.OfferVoucher.Threashold - tempBasket.Total;
                double extraNeeded = 0.01 + difference;


                Basket.Notifications.Add(
                    new Notification(
                   new ContentString().GetError("Errors_TotalNotMatchThreashold")
                       .FormatLiteralArguments(Basket.OfferVoucher.Code, Math.Round(extraNeeded, 2), Basket.OfferVoucher.Value)));
            }
        }

        private ShoppingBasketDto CreateTempBasket()
        {
            var productList = new List<ProductDto>();
            productList.AddRange(this.Basket.Products);

            var tempBasket = new ShoppingBasketDto()
            {
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
