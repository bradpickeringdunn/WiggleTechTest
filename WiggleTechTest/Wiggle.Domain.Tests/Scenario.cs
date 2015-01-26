using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiggle.Domain.PurchaseRules;
using Wiggle.Domain.ShoppingBasket;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;
using System.Collections.Generic;

namespace Wiggle.Domain.Tests
{
    [TestClass]
    public class Scenario
    {
        IOfferVoucherRules OfferRules;
        IShoppingBasketProducts ShoppingBasketProducts;

        [TestInitialize]
        public void Initialize()
        {
            OfferRules = new OfferVoucherRules();
            ShoppingBasketProducts = new ShoppingBasketProducts(OfferRules);
        }

        [TestMethod]
        public void ScenarioTest1()
        {
            var firstProduct = new ProductDto()
            {
                Name = "Hat",
                Price = 10.5,
                Category = ProductCategoryEnum.Clothing
            };

            var secondProduct = new ProductDto()
            {
                Name = "Jumper",
                Price = 54.65,
                Category = ProductCategoryEnum.Clothing
            };

            var giftVoucher = new GiftVoucherDto("XXX-XX", 5);

            var basket = new ShoppingBasketDto()
            {
                Products = new List<ProductDto>(){
                    firstProduct,
                    secondProduct
                },
                GiftVouchers = new List<GiftVoucherDto>() { giftVoucher }
            };

            basket.CalculateTotal();

            Assert.IsFalse(basket.Notifications.HasErrors);
            Assert.IsTrue(basket.Total == 60.15);
        }

        [TestMethod]
        public void ScenarioTest2()
        {            
            var firstProduct = new ProductDto()
            {
                Name = "Hat",
                Price = 26,
                Category = ProductCategoryEnum.Clothing
            };

            var secondProduct = new ProductDto()
            {
                Name = "Jumper",
                Price = 26,
                Category = ProductCategoryEnum.Clothing
            };

            var offerVoucher = new OfferVoucherDto("YYY-YYY ", 5, 50, ProductCategoryEnum.HeadGear, OfferVoucherType.Product);

            var basket = new ShoppingBasketDto()
            {
                Products = new List<ProductDto>(){
                    firstProduct,
                    secondProduct
                },
                OfferVoucher = offerVoucher
            };

            basket = OfferRules.Validate(basket);
            basket.CalculateTotal();

            Assert.IsTrue(basket.Notifications.HasErrors);
        }

        [TestMethod]
        public void ScenarioTest3()
        {
            var firstProduct = new ProductDto()
            {
                Name = "Hat",
                Price = 25,
                Category = ProductCategoryEnum.Clothing
            };

            var secondProduct = new ProductDto()
            {
                Name = "Jumper",
                Price = 26,
                Category = ProductCategoryEnum.Clothing
            };

            var thirdProduct = new ProductDto()
            {
                Name = "Headl Lght",
                Price = 3.5,
                Category = ProductCategoryEnum.HeadGear
            };

            var offerVoucher = new OfferVoucherDto("YYY-YYY ", 5, 50, ProductCategoryEnum.HeadGear, OfferVoucherType.Product);

            var basket = new ShoppingBasketDto()
            {
                Products = new List<ProductDto>(){
                    firstProduct,
                    secondProduct,
                    thirdProduct
                },
                OfferVoucher = offerVoucher
            };

            basket = OfferRules.Validate(basket);
            basket.CalculateTotal();
        }

        [TestMethod]
        public void ScenarioTest4()
        {
            var firstProduct = new ProductDto()
            {
                Name = "Hat",
                Price = 25,
                Category = ProductCategoryEnum.Clothing
            };

            var secondProduct = new ProductDto()
            {
                Name = "Jumper",
                Price = 26,
                Category = ProductCategoryEnum.Clothing
            };

            var giftVoucher = new GiftVoucherDto("XXX-XX", 5);
            var offerVoucher = new OfferVoucherDto("YYY-YYY ", 5, 50, ProductCategoryEnum.HeadGear, OfferVoucherType.ShoppingBasket);
            var basket = new ShoppingBasketDto()
            {
                Products = new List<ProductDto>(){
                    firstProduct,
                    secondProduct
                },
                GiftVouchers = new List<GiftVoucherDto>(){ giftVoucher},
                OfferVoucher = offerVoucher
            };

            basket = OfferRules.Validate(basket);
            basket.CalculateTotal();
        }

        [TestMethod]
        public void ScenarioTest5()
        {
            var firstProduct = new ProductDto()
            {
                Name = "Hat",
                Price = 26,
                Category = ProductCategoryEnum.Clothing
            };

            var secondProduct = new ProductDto()
            {
                Name = "Gift Voucher",
                Price = 30,
                Category = ProductCategoryEnum.GiftVoucher
            };

            var offerVoucher = new OfferVoucherDto("YYY-YYY ", 5, 50, ProductCategoryEnum.HeadGear, OfferVoucherType.Product);

            var basket = new ShoppingBasketDto()
            {
                Products = new List<ProductDto>(){
                    firstProduct,
                    secondProduct
                },
                OfferVoucher = offerVoucher
            };

            basket = OfferRules.Validate(basket);
            basket.CalculateTotal();
        }
    }
}
