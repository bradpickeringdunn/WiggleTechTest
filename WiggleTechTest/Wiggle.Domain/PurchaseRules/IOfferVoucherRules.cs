using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules
{
    public interface IOfferVoucherRules
    {
        ShoppingBasketDto Validate(ShoppingBasketDto basket);
    }
}
