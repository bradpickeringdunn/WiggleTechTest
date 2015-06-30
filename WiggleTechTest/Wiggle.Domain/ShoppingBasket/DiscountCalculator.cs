
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
        public static decimal Calculate(decimal cost, decimal discountValue)
        {
            decimal discountAmmount = 0;

            if (cost < discountValue)
            {
                var difference = discountAmmount - cost;
                discountAmmount -= difference;
            }
            
            return discountAmmount;
        }
    }
}
