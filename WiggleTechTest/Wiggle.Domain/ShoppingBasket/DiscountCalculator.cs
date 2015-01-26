using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Products;

namespace Wiggle.Domain.ShoppingBasket
{
    /// <summary>
    /// Apply caluclations for discounts
    /// </summary>
    public static class DiscountCalculator
    {
        /// <summary>
        /// Return the discount ammount based on the cost of a product.
        /// </summary>
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
