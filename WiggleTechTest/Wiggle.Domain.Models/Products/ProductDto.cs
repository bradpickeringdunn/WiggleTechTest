
using System.Runtime.Serialization;
using Wiggle.Service.Models.Common;
namespace Wiggle.Service.Models.Products
{
    [DataContract]
    public class ProductDto : BaseDto
    {
        public ProductDto(int id, decimal price, string name, ProductCategoryEnum category)
        {
            Price = price;
            Id = id;
            Category = category;
            Name = name;
        }
        
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public decimal Price { get; private set; }

        [DataMember]
        public ProductCategoryEnum Category { get; private set; }

    }
}
