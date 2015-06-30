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
        public void Scenario1()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                Products = new System.Collections.Generic.List<ProductDto>()
                {
                    new ProductDto()
                    {
                        Name = "Hat",
                        Price = 10.50m
                    },
                    new ProductDto()
                    {
                        Name = "Jumper",
                        Price = 54.65m
                    }
                },
                OfferVoucher = new OfferVoucherDto("XXX-XXX", 5.00m, 0, ProductCategoryEnum.Clothing, OfferVoucherType.ShoppingBasket)
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 60.15m);

        }

        [TestMethod]
        public void Scenario2()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                Products = new System.Collections.Generic.List<ProductDto>()
                {
                    new ProductDto()
                    {
                        Name = "Hat",
                        Price = 25.00m,
                        Category = ProductCategoryEnum.Clothing
                    },
                    new ProductDto()
                    {
                        Name = "Jumper",
                        Price = 26.00m,
                        Category = ProductCategoryEnum.Clothing
                    }
                },
                OfferVoucher = new OfferVoucherDto("YYY-YYY ", 5.00m, 0, ProductCategoryEnum.Clothing, OfferVoucherType.ShoppingBasket)
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 51.00m);
            Assert.IsTrue(result.Notifications.HasErrors);
            
        }

        [TestMethod]
        public void Scenario3()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                Products = new System.Collections.Generic.List<ProductDto>()
                {
                    new ProductDto()
                    {
                        Name = "Hat",
                        Price = 25.00m,
                        Category = ProductCategoryEnum.Clothing
                    },
                    new ProductDto()
                    {
                        Name = "Jumper",
                        Price = 26.00m,
                        Category = ProductCategoryEnum.Clothing
                    },
                    new ProductDto()
                    {
                        Name = "Head Light ",
                        Price = 3.50m,
                        Category = ProductCategoryEnum.HeadGear
                    }
                },

                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, ProductCategoryEnum.HeadGear, OfferVoucherType.Product)
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 51.00m);
            Assert.IsFalse(result.Notifications.HasErrors);

        }

        [TestMethod]
        public void Scenario4()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                Products = new System.Collections.Generic.List<ProductDto>()
                {
                    new ProductDto()
                    {
                        Name = "Hat",
                        Price = 25.00m,
                        Category = ProductCategoryEnum.Clothing
                    },
                    new ProductDto()
                    {
                        Name = "Jumper",
                        Price = 26.00m,
                        Category = ProductCategoryEnum.Clothing
                    }
                },

                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, null, OfferVoucherType.ShoppingBasket),
                GiftVouchers = new List<GiftVoucherDto>()
                {
                    new GiftVoucherDto("XXX-XXX",5m)
                }
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 41.00m);
            Assert.IsFalse(result.Notifications.HasErrors);

        }

        [TestMethod]
        public void Scenario5()
        {
            var repo = A.Fake<IRepository>();
            var logger = A.Fake<ILogger>();

            var service = new Wiggle.Service.ShoppingBasketService(repo, logger);

            var basket = new ShoppingBasketDto()
            {
                Products = new System.Collections.Generic.List<ProductDto>()
                {
                    new ProductDto()
                    {
                        Name = "Hat",
                        Price = 25.00m,
                        Category = ProductCategoryEnum.Clothing
                    },
                    new ProductDto()
                    {
                        Name = "Gift Voucher",
                        Price = 30.00m,
                        Category = ProductCategoryEnum.GiftVoucher
                    }
                },

                OfferVoucher = new OfferVoucherDto("YYY-YYY", 5.00m, 50m, null, OfferVoucherType.ShoppingBasket)
            };

            var request = new CalculateBasketTotalRequest()
            {
                Basket = basket
            };

            var result = service.CalculateBasketTotal(request);

            Assert.AreEqual(result.Total, 55.00m);
            Assert.IsTrue(result.Notifications.HasErrors);

        }
    }
}
