
using Backbone.Utilities;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket;
namespace Wiggle.Domain.PurchaseRules
{
    /// <summary>
    /// Class for the routing of offer voucher rules.
    /// </summary>
    public class OfferVoucherRules
    {
        private ShoppingBasketDto Basket { get; set; }

        /// <summary>
        /// Determins validation path based on vouch type.
        /// </summary>
        public ShoppingBasketDto Validate(ShoppingBasketDto basket)
        {
            Guardian.ArgumentNotNull(basket, "basket");
            Guardian.InstanceNotNull(basket.OfferVoucher, "OfferVoucher");

            this.Basket = basket;

            if (basket.OfferVoucher.IsApplicableTo == OfferVoucherType.ShoppingBasket)
            {
                basket = new ShoppingBaskets.ShoppingBasketOfferVoucherRules().ApplyOfferVoucher(basket);
            }

            if (basket.OfferVoucher.IsApplicableTo == OfferVoucherType.Product)
            {
                basket = new ProductPurchaeRules().ApplyOfferVoucher(basket);
            }

            return this.Basket;
        }
    }
}

