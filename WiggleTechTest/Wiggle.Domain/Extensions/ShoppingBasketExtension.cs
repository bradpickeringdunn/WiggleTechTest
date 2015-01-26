using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.PurchaseRules;

namespace Wiggle.Domain.Extensions
{
    public static class ShoppingBasketExtension
    {
        public static void CalculateTotal(this ShoppingBasketDto basket)
        {
            basket.Total = 0;

            if (basket.Products.Any())
            {
                foreach (var product in basket.Products)
                {
                    basket.Total += product.Price;
                }
            }

            if (basket.OfferVoucher.IsNotNull())
            {
                basket = new PurchaseRules.OfferVoucherRules().Validate(basket);
            }

            if (basket.GiftVouchers.Any())
            {
                foreach (var voucher in basket.GiftVouchers)
                {
                    basket.Total -= voucher.Value;
                }
            }
        }
    }
}
