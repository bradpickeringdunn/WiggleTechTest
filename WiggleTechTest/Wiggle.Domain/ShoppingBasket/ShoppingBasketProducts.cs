using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;
using Wiggle.Domain.Extensions;

namespace Wiggle.Domain.ShoppingBasket
{
    public class ShoppingBasketProducts : IShoppingBasketProducts
    {
        public ShoppingBasketDto AddProduct(ShoppingBasketDto basket, ProductDto product)
        {
            basket.Products.Add(product);

            basket.CalculateTotal();

            return basket;
        }

        public ShoppingBasketDto RemoveProduct(ShoppingBasketDto basket, ProductDto product)
        {

            basket.Products.Remove(product);
            return basket;
        }

        public ShoppingBasketDto ApplyGiftVoucer(ShoppingBasketDto basket, GirftVoucherDto giftVoucher)
        {
            basket.GiftVouchers.Add(giftVoucher);

            return basket;
        }

        public ShoppingBasketDto RemoveGiftVoucher(ShoppingBasketDto basket, GirftVoucherDto giftVoucher)
        {
            basket.GiftVouchers.Remove(giftVoucher);

            return basket;
        }

        public ShoppingBasketDto AddOfferVoucher(ShoppingBasketDto basket, OfferVoucherDto offerVoucher)
        {
            basket.OfferVoucher = offerVoucher;

            return basket;
        }

        public ShoppingBasketDto RemoveOfferVoucher(ShoppingBasketDto basket)
        {
            basket.OfferVoucher = null;

            return basket;
        }
    }
}
