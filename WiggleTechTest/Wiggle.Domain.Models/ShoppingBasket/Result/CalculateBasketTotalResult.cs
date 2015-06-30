using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Backbone.Services.Results;

namespace Wiggle.Service.Models.ShoppingBasket.Result
{
    [DataContract]
    public class CalculateBasketTotalResult : GenericServiceResult
    {
        [DataMember]
        public decimal Total { get; set; }
    }
}
