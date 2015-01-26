using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Products;

namespace Wiggle.Domain.ShoppingBasket
{
    public static class DiscountCalculator
    {
        public static double Calculate(double cost, double discountValue)
        {
            double discountAmmount = 0;

            if (cost < discountValue)
            {
                var difference = discountAmmount - cost;
                discountAmmount -= difference;
            }
            
            return discountAmmount;
        }
    }
}
