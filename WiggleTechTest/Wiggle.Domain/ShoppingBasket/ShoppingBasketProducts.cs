using System;
using Wiggle.Domain.PurchaseRules;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket;

namespace Wiggle.Domain.ShoppingBasket
{
    /// <summary>
    /// Governs the actions for product in a shopping basket
    /// </summary>
    public class ShoppingBasketProducts
    {
        private OfferVoucherRules OfferVoucherRules{get;set;}

        /// <summary>
        /// Constructor for passing dependencies
        /// </summary>
        public ShoppingBasketProducts(OfferVoucherRules offerVoucherRules)
        {
            OfferVoucherRules = offerVoucherRules;
        }

        /// <summary>
        /// Add a product to a basket
        /// </summary>
        public ShoppingBasketDto AddProduct(ShoppingBasketDto basket, ProductDto product)
        {
            basket.Products.Add(product);

            if (basket.OfferVoucher.IsNotNull())
            {
                basket = this.OfferVoucherRules.Validate(basket);
            }

            basket.CalculateTotal();

            return basket;
        }

    }
}
