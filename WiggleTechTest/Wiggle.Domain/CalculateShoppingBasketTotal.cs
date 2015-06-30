using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Service.Models.Products;

namespace Wiggle.Domain
{
    public class CalculateShoppingBasketTotal
    {
        public decimal CalculateVoucherTotal(decimal shoppingBasketTotal, OfferVoucherDto offer)
        {
            var discount = shoppingBasketTotal - offer.Value;

            if (discount < offer.Threashold)
            {
                discount = shoppingBasketTotal;
            }

            return shoppingBasketTotal - discount;
        }
    }
}
