using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.PurchaseRules;

namespace Wiggle.Domain.ShoppingBasket
{
    /// <summary>
    /// Governs the actions for product in a shopping basket
    /// </summary>
    public class ShoppingBasketProducts : IShoppingBasketProducts
    {
        private IOfferVoucherRules OfferVoucherRules{get;set;}

        /// <summary>
        /// Constructo for passing dependacy
        /// </summary>
        public ShoppingBasketProducts(IOfferVoucherRules offerVoucherRules)
        {
            this.OfferVoucherRules = offerVoucherRules;
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
