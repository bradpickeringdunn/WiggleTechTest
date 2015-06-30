
using System.Runtime.Serialization;
using Wiggle.Service.Models.Common;
namespace Wiggle.Service.Models.Products
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

        public OfferVoucherDto(string code, decimal value, decimal threashold, ProductCategoryEnum? productCategory, OfferVoucherType isApplicableTo)
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
