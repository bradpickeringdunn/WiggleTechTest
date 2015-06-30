using System.Collections.Generic;
using System.Runtime.Serialization;
using Backbone.ErrorHandling;
using Wiggle.Service.Models.Common;
using Wiggle.Service.Models.Products;

namespace Wiggle.Service.Models.ShoppingBasket
{
    [DataContract]
    public class ShoppingBasketDto : BaseDto
    {
        public ShoppingBasketDto()
        {
            Notifications = new NotificationCollection();
            Products = new List<ProductDto>();
            GiftVouchers = new List<GiftVoucherDto>();
        }

        [DataMember]
        public List<ProductDto> Products { get; set; }

        [DataMember]
        public NotificationCollection Notifications { get; set; }

        [DataMember]
        public List<GiftVoucherDto> GiftVouchers { get; set; }

        [DataMember]
        public OfferVoucherDto OfferVoucher { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public decimal? AppliedDiscount { get; set; }

        public decimal GetCostOfProducts()
        {
            var total = 0m;

            Products.ForEach((product) =>
            {
                total += product.Price;
            });

            return total;
        }
    }
}
