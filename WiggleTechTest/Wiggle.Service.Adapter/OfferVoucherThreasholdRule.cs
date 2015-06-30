using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Service.Api.Contract;

namespace Wiggle.Service.Adapter
{
    public class OfferVoucherThreasholdRule : IOfferVoucherThreasholdRule
    {
        public Models.ShoppingBasket.ShoppingBasketDto Validate(Models.ShoppingBasket.ShoppingBasketDto basket)
        {
            throw new NotImplementedException();
        }
    }
}
