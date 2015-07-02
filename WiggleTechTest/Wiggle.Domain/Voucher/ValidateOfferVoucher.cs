using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.ErrorHandling;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket;
using Wiggle.Service.Models.ShoppingBasket.Result;

namespace Wiggle.Domain
{
    public class ValidateOfferVoucher
    {
        IList<OfferVoucherDto> offerVouchers;
        
        public ValidateOfferVoucher()
        {
            offerVouchers = LoadMockVouchers();
        }

        public decimal CalculateVoucherTotal(decimal shoppingBasketTotal, OfferVoucherDto offer)
        {
            var discount = shoppingBasketTotal - offer.Value;

            if (discount < offer.Threashold)
            {
                discount = shoppingBasketTotal;
            }

            return shoppingBasketTotal - discount;
        }

        public ShoppingBasketDto ValidateSpendThreashHold(ShoppingBasketDto basket)
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

            if (totalProductValue < basket.Total)
            {
                basket.Total -= totalProductValue;
            }

            if (totalProductValue < basket.OfferVoucher.Threashold)
            {
                var additionalSpend = 0.00m;
                additionalSpend = (basket.OfferVoucher.Threashold - totalProductValue) + 0.01m;
                notifications.Add("You have not reached the spend threshold for voucher {0}. Spend another £{1} to receive £5.00 discount from your basket total."
                        .FormatLiteralArguments(basket.OfferVoucher.Code, additionalSpend));

                basket.Notifications = notifications;
                basket.Total += totalProductValue;
            }

            return basket;
        }

        public NotificationCollection ValidateOffer(ShoppingBasketDto basket)
        {
            var notifications = new NotificationCollection();
            OfferVoucherDto offer = null;
            
            if (offerVouchers.Any(v => v.Code == basket.OfferVoucher.Code))
            {
                offer = offerVouchers.FirstOrDefault(v => v.Code == basket.OfferVoucher.Code && v.IsApplicableTo == basket.OfferVoucher.IsApplicableTo);
            }
            else
            {
                notifications.Add("The offer voucher is not valid");
            }

            if (!notifications.HasErrors)
            {
                var offerAppliesToBasket = false;

                if (offer.IsApplicableTo == OfferVoucherType.Product)
                {
                    offerAppliesToBasket = basket.Products.Any(p => p.Category == offer.ProductCatergoy);
                }

                if (offer.IsApplicableTo == OfferVoucherType.ShoppingBasket)
                {
                    offerAppliesToBasket = true;
                }

                if (!offerAppliesToBasket)
                {
                    notifications.Add("There are no products in your basket applicable to voucher Voucher {0}.".FormatLiteralArguments(offer.Code));
                }
            }

            return notifications;
        }

        public IList<OfferVoucherDto> LoadMockVouchers()
        {
            return new List<OfferVoucherDto>()
            {
                new OfferVoucherDto("XXX-XXX", 5.00m, 0.00m,null, OfferVoucherType.ShoppingBasket),
                new OfferVoucherDto("YYY-YYY", 5m, 50m, ProductCategoryEnum.HeadGear, OfferVoucherType.Product),
                new OfferVoucherDto("YYY-YYY", 5m, 50m, null, OfferVoucherType.ShoppingBasket)
            };
        }
    }
}
