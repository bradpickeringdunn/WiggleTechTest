using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Service.Models.ShoppingBasket.Request;
using Wiggle.Service.Models.ShoppingBasket.Result;

namespace Wiggle.Service.Api.Contract
{
    [ServiceContract]
    public interface IShoppingBasketServiceContract
    {
        [OperationContract]
        CalculateBasketTotalResult CalculateBasketTotal(CalculateBasketTotalRequest request);
    }
}
