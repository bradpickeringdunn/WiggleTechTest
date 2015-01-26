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

            if(!basket.Notifications.HasErrors){
                CheckOfferVoucherThreshold();
            }

            if (!basket.Notifications.HasErrors)
            {
                ApplyOfferToBasket();
            }

            return this.Basket;
        }

        private void ApplyOfferToBasket()
        {
            Basket.Total -= Basket.OfferVoucher.Value;
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
    }
}
