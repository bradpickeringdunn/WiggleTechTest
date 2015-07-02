using System.Collections.Generic;
using Backbone.Logging;
using Backbone.Repository;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.Products.Vouchers;
using Wiggle.Service.Models.ShoppingBasket;
using Wiggle.Service.Models.ShoppingBasket.Request;

namespace Wiggle.Domain.Tests.ShoppingBasket
{
    [TestClass]
    public class ShoppingBasketProducts
    {
        [TestMethod]
        public void Scenario_1_Ensure_ShoppingBasketService_Returns_Total_65_15()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                GiftVouchers = new List<GiftVoucherDto>()
                {
                    new GiftVoucherDto("XXX-XXX", 5m)
                }
            };

            basket.Products.Add(new ProductDto(1, 10.50m, "Hat",ProductCategoryEnum.Clothing));
            basket.Products.Add(new ProductDto(1, 54.65m, "Jumper", ProductCategoryEnum.Clothing));

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Basket.SubTotal, 60.15m);
            Assert.IsFalse(result.Basket.Notifications.HasErrors);

        }

        [TestMethod]
        public void Scenario_2_Ensure_ShoppingBasketService_Returns_Total_51_With_No_HeadGear_Offer_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, OfferVoucherType.Product, ProductCategoryEnum.HeadGear)
            };

            basket.Products.Add(new ProductDto(1, 25.00m,"Hat", ProductCategoryEnum.Clothing));
            basket.Products.Add(new ProductDto(1, 26.00m, "Jumper", ProductCategoryEnum.Clothing ));

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "There are no products in your basket applicable to voucher Voucher YYY-YYY .";

            Assert.AreEqual(result.Basket.SubTotal, 51.00m);
            Assert.IsTrue(result.Basket.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Basket.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);
        }

        [TestMethod]
        public void Scenario_3_Ensure_ShoppingBasketService_Returns_Total_51_With_HeadGear_Offer_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, OfferVoucherType.Product, ProductCategoryEnum.HeadGear)
            };

            basket.Products.Add(new ProductDto(1, 25.00m, "Hat", ProductCategoryEnum.Clothing));
            basket.Products.Add(new ProductDto(2, 26.00m, "Jumper", ProductCategoryEnum.Clothing));
            basket.Products.Add(new ProductDto(3, 3.50m, "Head Light ", ProductCategoryEnum.HeadGear));

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Basket.SubTotal, 51.00m);
            Assert.IsFalse(result.Basket.Notifications.HasErrors);

        }

        [TestMethod]
        public void Scenario_4_Ensure_ShoppingBasketService_Returns_Total_41_With_Offer_And_GiftVoucher_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, OfferVoucherType.ShoppingBasket),
                GiftVouchers = new List<GiftVoucherDto>()
                {
                    new GiftVoucherDto("XXX-XXX",5m)
                }
            };

            basket.Products.Add(new ProductDto(1, 25.00m, "Hat",ProductCategoryEnum.Clothing));
            basket.Products.Add(new ProductDto(2, 26.00m, "Jumper",ProductCategoryEnum.Clothing));
            
            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Basket.SubTotal, 41.00m);
            Assert.IsFalse(result.Basket.Notifications.HasErrors);

        }

        [TestMethod]
        public void Scenario_5_Service_Ensure_ShoppingBasketService_Returns_Total_55_With_Offer_Not_Meeting_Offer_ThreashHold()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, OfferVoucherType.ShoppingBasket)
            };

            basket.Products.Add(new ProductDto(1, 25.00m, "Hat", ProductCategoryEnum.Clothing ));
            basket.Products.Add(new ProductDto(2, 30.00m, "Gift Voucher", ProductCategoryEnum.GiftVoucher ));

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };
          
            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.";

            Assert.AreEqual(result.Basket.SubTotal, 55.00m);
            Assert.IsTrue(result.Basket.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Basket.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);
        }

        [TestMethod]
        public void Service_Ensure_ShoppingBasketService_Returns_Error_If_No_Product_In_Basket()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, OfferVoucherType.ShoppingBasket)
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "This basket is empty.";

            Assert.AreEqual(result.Basket.SubTotal, 0m);
            Assert.IsTrue(result.Basket.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Basket.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);

        }

        [TestMethod]
        public void ServiceTest_Ensure_ShoppingBasketService_Returns_Total_81_With_No_HeadGear_Offer_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 0, OfferVoucherType.Product, ProductCategoryEnum.HeadGear)
            };

            basket.Products.Add(new ProductDto(1, 25.00m, "Hat",ProductCategoryEnum.Clothing ));
            basket.Products.Add(new ProductDto(1, 26.00m, "Jumper", ProductCategoryEnum.Clothing ));
            basket.Products.Add(new ProductDto(3, 30m, "Shirt", ProductCategoryEnum.GiftVoucher ));

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "There are no products in your basket applicable to voucher Voucher YYY-YYY .";

            Assert.AreEqual(result.Basket.SubTotal, 81.00m);
            Assert.IsTrue(result.Basket.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Basket.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);
        }

        [TestMethod]
        public void ServiceTest_Ensure_ShoppingBasketService_Returns_Total_51_With_30_GiftVoucher_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                GiftVouchers = new List<GiftVoucherDto>()
                {
                    new GiftVoucherDto("XXX-XXX",30m)
                }
            };

            basket.Products.Add(new ProductDto(1, 25.00m, "Hat", ProductCategoryEnum.Clothing ));
            basket.Products.Add(new ProductDto(1, 26.00m, "Jumper", ProductCategoryEnum.Clothing ));
            basket.Products.Add(new ProductDto(3, 30m, "Shirt", ProductCategoryEnum.GiftVoucher ));

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Basket.SubTotal, 51.00m);
            Assert.IsFalse(result.Basket.Notifications.HasErrors);
        }
    }
}
