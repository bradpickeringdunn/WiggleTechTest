using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.PurchaseRules;

namespace Wiggle.Domain
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
                    basket.Total += Math.Round(product.Price, 2);
                }

                if (basket.GiftVouchers.Any())
                {
                    basket.GiftVouchers.ForEach(voucher =>
                    {
                        //TODO This will result in negative total.  Chekc with client for extra logic.
                        basket.Total -= voucher.Value;
                    });
                }

                if (basket.AppliedDiscount.HasValue)
                {
                    basket.Total -= basket.AppliedDiscount.Value;
                }

                basket.Total = Math.Round(basket.Total, 2);
            }
        }
    }
}
