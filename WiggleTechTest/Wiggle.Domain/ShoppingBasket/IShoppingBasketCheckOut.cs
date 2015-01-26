using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Common;
using Wiggle.Domain.Models.ShoppingBasket;
using Model = Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.ShoppingBasket
{
    public interface IShoppingBasketCheckOut
    {
        Model.ShoppingBasketDto AdjustForOrderVouchers(Model.ShoppingBasketDto basket);
    }
}
