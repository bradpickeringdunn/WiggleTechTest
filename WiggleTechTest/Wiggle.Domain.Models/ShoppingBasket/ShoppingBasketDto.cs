using Backbone.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Common;
using Wiggle.Domain.Models.Products;

namespace Wiggle.Domain.Models.ShoppingBasket
{
    public class ShoppingBasketDto : BaseDto
    {
        public ShoppingBasketDto()
        {
            Notifications = new NotificationCollection();
            Products = new List<ProductDto>();
            GiftVouchers = new List<GiftVoucherDto>();
        }

        public List<ProductDto> Products { get; set; }

        public NotificationCollection Notifications { get; set; }

        public List<GiftVoucherDto> GiftVouchers { get; set; }

        public OfferVoucherDto OfferVoucher { get; set; }

        public double Total { get; set; }

        public double? AppliedDiscount { get; set; }
    }
}
