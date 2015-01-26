using Backbone.ErrorHandling;
using Backbone.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiggle.Domain.Models.Common;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.ShoppingBasket;
using Model = Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules
{
    public class ProductPurchaeRules
    {
        private ShoppingBasketDto Basket { get; set; }
                        
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
