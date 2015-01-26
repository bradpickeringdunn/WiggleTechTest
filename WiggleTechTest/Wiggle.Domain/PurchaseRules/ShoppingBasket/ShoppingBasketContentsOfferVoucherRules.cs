using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules.ShoppingBaskets
{
    public class ShoppingBasketContentsRules
    {
        private ShoppingBasketDto Basket {get;set;}

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
