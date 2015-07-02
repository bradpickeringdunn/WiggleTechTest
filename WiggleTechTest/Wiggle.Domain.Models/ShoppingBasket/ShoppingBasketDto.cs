using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Backbone.ErrorHandling;
using Wiggle.Service.Models.Common;
using Wiggle.Service.Models.Products;
using System;

namespace Wiggle.Service.Models.ShoppingBasket
{
    [DataContract]
    public class ShoppingBasketDto : BaseDto
    {
        private decimal totalBasketCost;
        private IList<ProductDto> products;

        public ShoppingBasketDto()
        {
            Initialize();
        }

        public ShoppingBasketDto(List<ProductDto> prodcuts)
        {
            Initialize();
            this.products = prodcuts;
            prodcuts.ForEach((product) =>
            {
                totalBasketCost += product.Price;
            });
        }

        [DataMember]
        public IList<ProductDto> Products
        {
            get
            {
                return products;
            }
        }

        [DataMember]
        public NotificationCollection Notifications { get; set; }

        [DataMember]
        public List<GiftVoucherDto> GiftVouchers { get; set; }

        [DataMember]
        public OfferVoucherDto OfferVoucher { get; set; }

        [DataMember]
        public decimal Total
        {
            get
            {
                return totalBasketCost;
            }
            set
            {
                totalBasketCost = value;
            }
        }

        [DataMember]
        public decimal? AppliedDiscount { get; set; }

        private void Initialize()
        {
            products = new List<ProductDto>();
            Notifications = new NotificationCollection();
            GiftVouchers = new List<GiftVoucherDto>();
        }

        public void AddProduct(ProductDto product)
        {
            products.Add(product);
            totalBasketCost += product.Price;
        }

        public void RemoveProduct(ProductDto product)
        {
            products.Remove(product);
            totalBasketCost += product.Price;
        }

        public void UpdateProduct(ProductDto product)
        {
            products.Remove(product);
            totalBasketCost -= product.Price;
            
            products.Add(product);
            totalBasketCost += product.Price;
        }
    }
}
