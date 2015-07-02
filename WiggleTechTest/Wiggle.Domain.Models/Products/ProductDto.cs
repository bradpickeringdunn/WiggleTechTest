
using System.Runtime.Serialization;
using Wiggle.Service.Models.Common;
namespace Wiggle.Service.Models.Products
{
    [DataContract]
    public class ProductDto : BaseDto
    {
        public ProductDto(int id, decimal price)
        {
            Price = price;
            Id = id;
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
