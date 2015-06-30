using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wiggle.Service.Models.ShoppingBasket.Request
{
    [DataContract]
    public class CalculateBasketTotalRequest
    {
        [DataMember]
        public ShoppingBasketDto Basket { get; set; }
    }
}
