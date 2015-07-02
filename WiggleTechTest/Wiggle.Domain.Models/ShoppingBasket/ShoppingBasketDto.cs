using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Backbone.ErrorHandling;
using Wiggle.Service.Models.Common;
using Wiggle.Service.Models.Products;
using System;
using Wiggle.Service.Models.Products.Vouchers;

namespace Wiggle.Service.Models.ShoppingBasket
{
    [DataContract]
    public class ShoppingBasketDto : BaseDto
    {
        private decimal subTotal;
        private decimal total;

        public ShoppingBasketDto()
        {
            Initialize();
        }

        /// <summary>
        /// A list of all products in a basket.
        /// </summary>
        [DataMember]
        public IList<ProductDto> Products{get;set;}

        /// <summary>
        /// Contains a list of all errors and warnings about the state of a basket.
        /// </summary>
        [DataMember]
        public NotificationCollection Notifications { get; set; }

        /// <summary>
        /// Gets and sets gift vouchers for a basket.
        /// </summary>
        [DataMember]
        public IList<GiftVoucherDto> GiftVouchers { get; set; }

        /// <summary>
        /// Gets and sets an offer to be applied to the basket.
        /// </summary>
        [DataMember]
        public OfferVoucherDto OfferVoucher { get; set; }

        /// <summary>
        /// The total of a baskets products.
        /// </summary>
        [DataMember]
        public decimal Total
        {
            get
            {
                total = 0m;

                foreach (var product in Products)
                {
                    total += product.Price;
                }

                return total;
            }
        }

        /// <summary>
        /// Gets and sets the value of a basket with all offers and gift vouchers applied.
        /// </summary>
        [DataMember]
        public decimal SubTotal
        {
            get
            {
                if (subTotal == 0)
                {
                    subTotal = Total;
                }
                return subTotal;
            }
            set
            {
                subTotal = value;
            }
        }

        private void Initialize()
        {
            Products = new List<ProductDto>();
            Notifications = new NotificationCollection();
            GiftVouchers = new List<GiftVoucherDto>();
            subTotal = 0m;
            total = 0m;
        }

    }
}
