using System.Runtime.Serialization;
using Wiggle.Service.Models.Common;

namespace Wiggle.Service.Models.Products.Vouchers
{
    [DataContract]
    public class OfferVoucherDto : BaseDto
    {
        [DataMember]
        public bool CanBeApplied { get; set; }

        [DataMember]
        public string Code{get;private set;}

        [DataMember]
        public decimal Value{get;private set;}

        [DataMember]
        public decimal Threashold { get; set; }

        [DataMember]
        public ProductCategoryEnum? ProductCatergoy { get; private set; }

        [DataMember]
        public OfferVoucherType IsApplicableTo { get; set; }

        public OfferVoucherDto(string code, decimal value, decimal threashold, OfferVoucherType isApplicableTo, ProductCategoryEnum? productCategory = null)
        {
            this.CanBeApplied = false;
            this.Code = code;
            this.Value = value;
            this.ProductCatergoy = productCategory;
            this.Threashold = threashold;
            this.IsApplicableTo = isApplicableTo;
        }
    }
}
