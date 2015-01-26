using Backbone.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules
{
    public class OfferVoucherRules : IOfferVoucherRules
    {
        private ShoppingBasketDto Basket { get; set; }

        public ShoppingBasketDto Validate(ShoppingBasketDto basket)
        {
            Guardian.ArgumentNotNull(basket, "basket");
            Guardian.InstanceNotNull(basket.OfferVoucher, "OfferVoucher");

            this.Basket = basket;

            if (basket.OfferVoucher.IsApplicableTo == OfferVoucherType.ShoppingBasket)
            {
                basket = new ShoppingBaskets.ShoppingBasketContentsRules().ApplyOfferVoucher(basket);
            }

            if (basket.OfferVoucher.IsApplicableTo == OfferVoucherType.Product)
            {
                basket = new ProductPurchaeRules().ApplyOfferVoucher(basket);
            }

            return this.Basket;
        }
    }
}

