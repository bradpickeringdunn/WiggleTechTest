
using System.Runtime.Serialization;
using Wiggle.Service.Models.Common;

namespace Wiggle.Service.Models.Products.Vouchers
{
    [DataContract]
    public class GiftVoucherDto : BaseDto
    {
        [DataMember]
        public string code { get; private set; }

        [DataMember]
        public decimal Value {get;private set;}
        
        public GiftVoucherDto(string existingVoucherCode, decimal value)
        {
            this.code = existingVoucherCode;
            this.Value = value;
        }
    }
}
