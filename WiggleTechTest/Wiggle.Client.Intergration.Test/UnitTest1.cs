using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiggle.Client.Intergration.Test.ShoppingBasketService;
using Wiggle.Service.Models.Products;
using ServiceModels = Wiggle.Service.Models;
using Wiggle.Client.Intergration.Test.Assemblers;

namespace Wiggle.Client.Intergration.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new ShoppingBasketServiceContractClient();

            var products = new List<ServiceModels.Products.ProductDto>(){
                new Service.Models.Products.ProductDto(1, 10.50m, "Hat", ProductCategoryEnum.Clothing),
                new Service.Models.Products.ProductDto(1, 54.65m, "Jumper", ProductCategoryEnum.Clothing)
            };

            var basket = new ShoppingBasketDto()
            {
                Products = products.AsProductModels()
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Basket.SubTotal, 60.15m);
        }
    }
}
