using System.Collections.Generic;
using Backbone.Logging;
using Backbone.Repository;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket;
using Wiggle.Service.Models.ShoppingBasket.Request;
using System.Linq;

namespace Wiggle.Domain.Tests.ShoppingBasket
{
    [TestClass]
    public class ShoppingBasketProducts
    {
        [TestMethod]
        public void ServiceTest_Ensure_ShoppingBasketService_Returns_Total_65_15()
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

            basket.AddProduct(new ProductDto(1, 10.50m) { Name = "Hat" });
            basket.AddProduct(new ProductDto(1, 54.65m) { Name = "Jumper" });

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 60.15m);

        }

        [TestMethod]
        public void ServiceTest_Ensure_ShoppingBasketService_Returns_Total_51_With_No_HeadGear_Offer_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 0, ProductCategoryEnum.HeadGear, OfferVoucherType.Product)
            };

            basket.AddProduct(new ProductDto(1, 25.00m) { Name = "Hat", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(1, 26.00m) { Name = "Jumper", Category = ProductCategoryEnum.Clothing });

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "There are no products in your basket applicable to voucher Voucher YYY-YYY .";

            Assert.AreEqual(result.Total, 51.00m);
            Assert.IsTrue(result.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);
        }

        [TestMethod]
        public void Service_Ensure_ShoppingBasketService_Returns_Total_51_With_HeadGear_Offer_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, ProductCategoryEnum.HeadGear, OfferVoucherType.Product)
            };

            basket.AddProduct(new ProductDto(1, 25.00m) { Name = "Hat", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(2, 26.00m) { Name = "Jumper", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(3, 3.50m) { Name = "Head Light ", Category = ProductCategoryEnum.HeadGear });

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 51.00m);
            Assert.IsFalse(result.Notifications.HasErrors);

        }

        [TestMethod]
        public void Service_Ensure_ShoppingBasketService_Returns_Total_41_With_Offer_And_GiftVoucher_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, null, OfferVoucherType.ShoppingBasket),
                GiftVouchers = new List<GiftVoucherDto>()
                {
                    new GiftVoucherDto("XXX-XXX",5m)
                }
            };

            basket.AddProduct(new ProductDto(1, 25.00m){Name = "Hat",Category = ProductCategoryEnum.Clothing});
            basket.AddProduct(new ProductDto(2, 26.00m){Name = "Jumper",Category = ProductCategoryEnum.Clothing});
            
            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 41.00m);
            Assert.IsFalse(result.Notifications.HasErrors);

        }

        [TestMethod]
        public void Service_Ensure_ShoppingBasketService_Returns_Total_55_With_Offer_Not_Meeting_Offer_ThreashHold()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, null, OfferVoucherType.ShoppingBasket)
            };

            basket.AddProduct(new ProductDto(1, 25.00m) { Name = "Hat", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(2, 30.00m) { Name = "Gift Voucher", Category = ProductCategoryEnum.GiftVoucher });

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };
          
            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.";

            Assert.AreEqual(result.Total, 55.00m);
            Assert.IsTrue(result.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);
        }

        [TestMethod]
        public void Service_Ensure_ShoppingBasketService_Returns_Error_If_No_Product_In_Basket()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, null, OfferVoucherType.ShoppingBasket)
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "This basket is empty.";

            Assert.AreEqual(result.Total, 0m);
            Assert.IsTrue(result.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);

        }

        [TestMethod]
        public void ServiceTest_Ensure_ShoppingBasketService_Returns_Total_81_With_No_HeadGear_Offer_Applied()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 0, ProductCategoryEnum.HeadGear, OfferVoucherType.Product)
            };

            basket.AddProduct(new ProductDto(1, 25.00m) { Name = "Hat", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(1, 26.00m) { Name = "Jumper", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(3, 30m) { Name = "", Category = ProductCategoryEnum.GiftVoucher });

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            var expectedErrorMessage = "There are no products in your basket applicable to voucher Voucher YYY-YYY .";

            Assert.AreEqual(result.Total, 81.00m);
            Assert.IsTrue(result.Notifications.HasErrors);
            Assert.IsTrue(((Backbone.ErrorHandling.Notification)(result.Notifications.Notifications[0])).Error.ErrorMessage == expectedErrorMessage);
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

            basket.AddProduct(new ProductDto(1, 25.00m) { Name = "Hat", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(1, 26.00m) { Name = "Jumper", Category = ProductCategoryEnum.Clothing });
            basket.AddProduct(new ProductDto(3, 30m) { Name = "", Category = ProductCategoryEnum.GiftVoucher });

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);
                        
            Assert.AreEqual(result.Total, 51.00m);
            Assert.IsFalse(result.Notifications.HasErrors);
        }
    }
}
