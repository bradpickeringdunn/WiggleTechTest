using System;
using System.Collections.Generic;
using Backbone.ErrorHandling;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.Products.Vouchers;
using Wiggle.Service.Models.ShoppingBasket;

namespace Wiggle.Domain
{
    public class ShoppingBasketOffer
    {
        private IList<OfferVoucherDto> offerVouchers;

        public ShoppingBasketOffer()
        {
            offerVouchers = LoadMockVouchers();
        }

        private bool OfferApplied { get; set; }

        public ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket)
        {
            basket = ValidateOffForBasket(basket);

            if (!basket.Notifications.HasErrors && basket.OfferVoucher.IsApplicableTo == OfferVoucherType.ShoppingBasket)
            {
                basket.SubTotal = basket.SubTotal - basket.OfferVoucher.Value;
                OfferApplied = true;
            }

            if (!basket.Notifications.HasErrors && basket.OfferVoucher.IsApplicableTo == OfferVoucherType.Product && !OfferApplied)
            {
                basket.SubTotal = ApplyOfferToProducts(basket.Products, basket.OfferVoucher, basket.Total);
            }

            if (!OfferApplied && !basket.Notifications.HasErrors)
            {
                basket.Notifications.Add("There are no products in your basket applicable to voucher Voucher {0} .".FormatLiteralArguments(basket.OfferVoucher.Code));
            }

            return basket;
        }

        private decimal ApplyOfferToProducts(IList<ProductDto> products, OfferVoucherDto offerVoucher, decimal basketTotalCost)
        {
            var offerApplied = false;
            var updatedTotalCost = 0m;

            foreach (var product in products)
            {
                if (product.Category == offerVoucher.ProductCatergoy && !offerApplied)
                {
                    OfferApplied = true;
                    var productPrice = product.Price;
                    productPrice -= offerVoucher.Value;
                    productPrice = productPrice >= 0 ? productPrice : 0m;
                    updatedTotalCost += productPrice;
                }
                else
                {
                    updatedTotalCost += product.Price;
                }
            }

            if (updatedTotalCost < offerVoucher.Threashold)
            {
                updatedTotalCost = offerVoucher.Threashold;
            }

            return updatedTotalCost;
        }
        
        public ShoppingBasketDto ValidateOffForBasket(ShoppingBasketDto basket)
        {
            var notifications = new NotificationCollection();
            var totalProductValue = 0.00m;
            
            foreach (var product in basket.Products)
            {
                if (product.Category != ProductCategoryEnum.GiftVoucher)
                {
                    totalProductValue += product.Price;
                }
            }

            //if (totalProductValue < basket.Total)
            //{
            //    totalProductValue = basket.Total - totalProductValue;
            //}

            if (totalProductValue < basket.OfferVoucher.Threashold)
            {
                var additionalSpend = 0.00m;
                additionalSpend = (basket.OfferVoucher.Threashold - totalProductValue) + 0.01m;
                notifications.Add("You have not reached the spend threshold for voucher {0}. Spend another £{1} to receive £5.00 discount from your basket total."
                        .FormatLiteralArguments(basket.OfferVoucher.Code, additionalSpend));

                basket.Notifications = notifications;
                totalProductValue = basket.Total;
            }

            basket.SubTotal = totalProductValue;

            return basket;
        }

        private IList<OfferVoucherDto> LoadMockVouchers()
        {
            return new List<OfferVoucherDto>()
            {
                new OfferVoucherDto("XXX-XXX", 5.00m, 0.00m,OfferVoucherType.ShoppingBasket),
                new OfferVoucherDto("YYY-YYY", 5m, 50m, OfferVoucherType.Product, ProductCategoryEnum.HeadGear),
                new OfferVoucherDto("YYY-YYY", 5m, 50m, OfferVoucherType.ShoppingBasket)
            };
        }
    }
}
