using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.PurchaseRules.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules.ShoppingBaskets
{
    /// <summary>
    /// Contails rules associated with offer vouchers for the discounting of a baskets contense.
    /// </summary>
    internal class ShoppingBasketOfferVoucherRules : IShoppingBasketOfferVoucherRules
    {
        private ShoppingBasketDto Basket {get;set;}

        /// <summary>
        /// Apply the rules for offer voucher.
        /// </summary>
        public ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket)
        {
            this.Basket = basket;

            if (!basket.Notifications.HasErrors)
            {
                this.Basket = new Common.OfferVoucherThreasholdRule().Validate(this.Basket);
            }

            if (!basket.Notifications.HasErrors)
            {
                ApplyOfferToBasket();
            }

            return this.Basket;
        }

        private void ApplyOfferToBasket()
        {
            Basket.AppliedDiscount = Basket.OfferVoucher.Value;
        }

    }
}
