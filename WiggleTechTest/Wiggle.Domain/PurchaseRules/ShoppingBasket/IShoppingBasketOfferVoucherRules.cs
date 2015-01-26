﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules.ShoppingBasket
{
    internal interface IShoppingBasketOfferVoucherRules
    {
        ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket);
    }
}