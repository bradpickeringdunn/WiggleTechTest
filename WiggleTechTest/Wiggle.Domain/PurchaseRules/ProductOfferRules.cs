using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules
{
    public class ProductOfferRules
    {
        public ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket)
        {
            

            if (!basket.Notifications.HasErrors)
            {
                var total = basket.GrossTotal;

                if (basket.OfferVoucher.IsNotNull())
                {
                    total -= basket.OfferVoucher.Value;
                }

                basket.SubTotal = total;
            }

            return basket;
        }
    }
}
