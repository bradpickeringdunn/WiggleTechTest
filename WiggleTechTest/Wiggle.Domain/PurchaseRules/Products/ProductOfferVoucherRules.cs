using Backbone.ErrorHandling;
using Backbone.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiggle.Domain.Models.Common;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;
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
                CheckOfferVoucherThreshold();
            }

            if (!Basket.Notifications.HasErrors)
            {
                OfferIsApplicableToAProduct();
            }
            
            return this.Basket;
        }
                
        private ShoppingBasketDto CheckOfferVoucherThreshold()
        {
            if (Basket.Total < Basket.OfferVoucher.Threashold)
            {
                Basket.Notifications.Add(
                   new Notification(
                       new Error("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total."))
                    );
            }

            return Basket;
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
                double discount = 0;

                if (product.Price < this.Basket.OfferVoucher.Value)
                {
                    discount = Basket.OfferVoucher.Value - product.Price;
                    discount = Math.Round(discount, 2);
                }

                product.Price -= discount;
                Basket.Total -= discount;
            }
        }

    }
}
