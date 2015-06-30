using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiggle.Domain.PurchaseRules;
using Wiggle.Domain.ShoppingBasket;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket;
using System.Linq;
using Wiggle.Service.Api.Contract;

namespace Wiggle.Domain.Tests
{
    [TestClass]
    public class Scenario
    {
        IOfferVoucherRules OfferRules;
        IShoppingBasketProducts ShoppingBasketProducts;
        //ContentString ContentString;

        [TestInitialize]
        public void Initialize()
        {
            //OfferRules = new OfferVoucherRules();
            //ShoppingBasketProducts = new ShoppingBasketProducts(OfferRules);
            //ContentString = new ContentString();
        }

        [TestMethod]
        public void ScenarioTest1()
        {
            var firstProduct = new ProductDto()
            {
                Name = "Hat",
                Price = decimal.Parse("10.5"),
                Category = ProductCategoryEnum.Clothing
            };

            var secondProduct = new ProductDto()
            {
                Name = "Jumper",
                Price = decimal.Parse("54.65"),Category = ProductCategoryEnum.Clothing
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
            Assert.IsTrue(basket.Total == decimal.Parse("60.15"));
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

            //var expectedErrorMessage = ContentString.GetError("Errors_NoProductMatchesVoucher").FormatLiteralArguments(basket.OfferVoucher.Code);

            Assert.IsTrue(basket.Notifications.HasErrors);
            //Assert.AreEqual(basket.Notifications.First().Error.ErrorMessage, expectedErrorMessage);
                
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
                Price = decimal.Parse("3.5"),
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
                Price = 25,
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

            //var expectedError = ContentString.GetError("Errors_TotalNotMatchThreashold").FormatLiteralArguments(basket.OfferVoucher.Code, 25.01, 5);

            Assert.IsTrue(basket.Notifications.HasErrors);
            //Assert.AreEqual(basket.Notifications.First().Error.ErrorMessage, expectedError);
        }
    }
}
