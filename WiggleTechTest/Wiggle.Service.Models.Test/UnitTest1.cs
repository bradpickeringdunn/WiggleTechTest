using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiggle.Service.Models.Products;

namespace Wiggle.Service.Models.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var shoppingBasket = new ShoppingBasket.ShoppingBasketDto();

            shoppingBasket.AddProduct(new ProductDto(1, 20) { Category = ProductCategoryEnum.Clothing });

            shoppingBasket.AddProduct(new ProductDto(2, 20m) { Category = ProductCategoryEnum.Clothing});
        }
    }
}
