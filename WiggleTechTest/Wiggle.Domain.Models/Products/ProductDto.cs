
using System.Runtime.Serialization;
using Wiggle.Service.Models.Common;
namespace Wiggle.Service.Models.Products
{
    [DataContract]
    public class ProductDto : BaseDto
    {
        public ProductDto()
        {
        }

        public ProductDto(OfferVoucherDto offerVoucher)
        {
            this.OfferVoucher = offerVoucher;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public ProductCategoryEnum Category { get; set; }

        [DataMember]
        public OfferVoucherDto OfferVoucher { get; private set; }
    }
}
