using Backbone.ErrorHandling;
using System;
using System.Linq;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules
{
    /// <summary>
    /// Continas all rules related to the purchase of a product.
    /// </summary>
    public class ProductPurchaeRules
    {
        private ShoppingBasketDto Basket { get; set; }
                     
        /// <summary>
        /// Run through the rules nessesary for the aplication of the specified voucher.  If no errors voucher is applied.
        /// </summary>
        public ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket)
        {
            this.Basket = basket;

            if (!Basket.Notifications.HasErrors)
            {
                new Common.OfferVoucherThreasholdRule().Validate(basket);
            }

            if (!Basket.Notifications.HasErrors)
            {
                OfferIsApplicableToAProduct();
            }
            
            return this.Basket;
        }                

        private void OfferIsApplicableToAProduct()
        {
            var product = Basket.Products.FirstOrDefault(p => p.Category == Basket.OfferVoucher.ProductCatergoy);

            if (product.IsNull())
            {
                Basket.Notifications.Add(
                    new Notification(
                        new Error("There are no products in your basket applicable to voucher Voucher YYY-YYY ")
                        )
                    );
            }

            if (product.IsNotNull())
            {
                double discount = DiscountCalculator.Calculate(product.Price, Basket.OfferVoucher.Value);
                product.Price -= discount;
            }
        }

    }
}
