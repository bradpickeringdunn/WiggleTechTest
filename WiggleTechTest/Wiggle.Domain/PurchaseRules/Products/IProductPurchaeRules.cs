﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.PurchaseRules.Products
{
    public interface IProductPurchaeRules
    {
        ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket);
    }
}