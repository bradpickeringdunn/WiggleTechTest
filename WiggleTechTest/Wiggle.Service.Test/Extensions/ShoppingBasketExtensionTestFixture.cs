using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket;
using Backbone;
using Wiggle.Service.Models.ShoppingBasket.Request;

namespace Wiggle.Domain.Tests.Extensions
{
    [TestClass]
    public class ShoppingBasketExtensionTestFixture
    {
        //[TestMethod]
        //public void ShoppingBasketExtension_Returns_0_If_No_Product_Or_Vouchers()
        //{
            
        //    //var basket = new ShoppingBasketDto();

        //    var basket = new ShoppingBasketDto()
        //    {
        //        GiftVouchers = new List<GiftVoucherDto>()
        //        {
        //            new GiftVoucherDto("code 1",5.00m)
        //        }
        //    };

        //    basket.AddProduct(new ProductDto(1, 10.50m){Category = ProductCategoryEnum.Clothing, Description = "Hat", IsActive = true});
        //    basket.AddProduct(new ProductDto(2,54.65m ){ Category = ProductCategoryEnum.Clothing, Description = "Jumper", IsActive = true});
             
        //    var request = new CalculateBasketTotalRequest()
        //    {
        //        Basket = basket
        //    };

        //    new Wiggle.Service.Test.ShoppingBasketService.ShoppingBasketServiceContractClient().CalculateBasketTotal(request);
        //    //basket.CalculateTotal();

        //    //Assert.IsFalse(basket.Notifications.HasErrors);
        //    //Assert.IsTrue(basket.Total == 0);

        //}

        //[TestMethod]
        //public void ShoppingBasketExtension_Returns_Product_Total_If_Or_Vouchers()
        //{
        //    var basket = new ShoppingBasketDto();
        //    basket.AddProduct(new ProductDto(1,5m));
        //            new ProductDto(){Price = 12}
        //        }


        //    ////basket.CalculateTotal();

        //    //Assert.IsFalse(basket.Notifications.HasErrors);
        //    //Assert.IsTrue(basket.Total == 17);

        //}

        //[TestMethod]
        //public void ShoppingBasketExtension_Returns_Discount_If_Has_GiftVoucher()
        //{
        //    var basket = new ShoppingBasketDto()
        //    {
        //        GiftVouchers = new List<GiftVoucherDto>(){
        //          new GiftVoucherDto(null,5)
        //        },
        //        Products = new List<ProductDto>()
        //        {
        //            new ProductDto(){Price = 5},
        //            new ProductDto(){Price = 12}
        //        }
        //    };

        //    //basket.CalculateTotal();

        //    //Assert.IsFalse(basket.Notifications.HasErrors);
        //    //Assert.IsTrue(basket.Total == 12);

        //}

        //[TestMethod]
        //public void ShoppingBasketExtension_Does_Not_Return_Discount_If_Has_OfferVoucher()
        //{
        //    var basket = new ShoppingBasketDto()
        //    {
        //       OfferVoucher = new OfferVoucherDto(null,15,0,ProductCategoryEnum.GiftVoucher,OfferVoucherType.ShoppingBasket),
        //        Products = new List<ProductDto>()
        //        {
        //            new ProductDto(){Price = 5},
        //            new ProductDto(){Price = 12}
        //        }
        //    };

        //    //basket.CalculateTotal();

        //    //Assert.IsFalse(basket.Notifications.HasErrors);
        //    //Assert.IsTrue(basket.Total == 17);

        //}

    }
}
