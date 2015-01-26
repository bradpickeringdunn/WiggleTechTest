using System;
using System.Linq;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain
{
    /// <summary>
    /// Extensions applied to instances of ShoppingBasketDto
    /// </summary>
    public static class ShoppingBasketExtension
    {
        /// <summary>
        /// Calculates the total cost of products.  Subtracts any gif voucchers and any discounts applied to the basket.
        /// </summary>
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
