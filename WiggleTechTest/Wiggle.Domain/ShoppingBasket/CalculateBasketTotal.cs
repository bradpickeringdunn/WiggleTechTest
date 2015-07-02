using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.Products.Vouchers;
using Wiggle.Service.Models.ShoppingBasket;
using Wiggle.Service.Models.ShoppingBasket.Result;

namespace Wiggle.Domain
{
    public class CalculateBasketTotal
    {
        private bool OfferApplied { get; set; }

        public ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket)
        {                        
            basket = new ShoppingBasketOffer().ValidateOffForBasket(basket);
            
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

        public decimal ApplyOfferToProducts(IList<ProductDto> products, OfferVoucherDto offerVoucher, decimal basketTotalCost)
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
    }
}
