using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.ErrorHandling;
using Wiggle.Domain.ShoppingBasket;
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

        public CalculateBasketTotalResult ApplyOfferVoucher(ShoppingBasketDto basket)
        {
            basket.Notifications = ValidateOffer(basket);
            var result = new CalculateBasketTotalResult();
            
            if (!basket.Notifications.HasErrors)
            {
                var totalValueOfProducts = basket.GetCostOfProducts();
                var offerApplied = false;

                basket = ValidateSpendThreashHold(basket);

                if (!basket.Notifications.HasErrors)
                {
                    if (basket.OfferVoucher.IsApplicableTo == OfferVoucherType.ShoppingBasket)
                    {
                        basket.Total = totalValueOfProducts - basket.OfferVoucher.Value;
                        offerApplied = true;
                    }

                    if (basket.OfferVoucher.IsApplicableTo == OfferVoucherType.Product && !offerApplied)
                    {
                        foreach (var product in basket.Products)
                        {
                            if (product.Category == basket.OfferVoucher.ProductCatergoy && !offerApplied)
                            {
                                offerApplied = true;
                                product.Price -= basket.OfferVoucher.Value;
                                product.Price = product.Price >= 0 ? product.Price : 0m;

                                if (basket.Total < basket.OfferVoucher.Threashold)
                                {
                                    basket.Total = basket.OfferVoucher.Threashold;
                                }
                            }
                        }

                        basket.Total = basket.GetCostOfProducts();
                    }
                }

                result.Notifications = basket.Notifications;
                result.Total = basket.Total;

            }
            else
            {
                result.Notifications = basket.Notifications;
                result.Total = basket.GetCostOfProducts();
            }

            return result;
        }

        private ShoppingBasketDto ValidateSpendThreashHold(ShoppingBasketDto basket)
        {
            var notifications = new NotificationCollection();
            var totalProductValue = 0.00m;
            basket.Total = basket.GetCostOfProducts();

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
                additionalSpend = basket.OfferVoucher.Threashold - (totalProductValue + 0.01m);
                notifications.Add("You have not reached the spend threshold for voucher {0}. Spend another £{1} to receive £5.00 discount from your basket total."
                        .FormatLiteralArguments(basket.OfferVoucher.Code, additionalSpend));

                basket.Notifications = notifications;
                basket.Total += totalProductValue;
            }

            return basket;
        }

        private NotificationCollection ValidateOffer(ShoppingBasketDto basket)
        {
            var notifications = new NotificationCollection();
            OfferVoucherDto offer = null;
            var totalCostOfProducts = basket.GetCostOfProducts();

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
                    notifications.Add("There are no products in your basket applicable to voucher Voucher {0} .".FormatLiteralArguments(offer.Code));
                }
            }

            return notifications;
        }
        
        private IList<OfferVoucherDto> LoadMockVouchers()
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
