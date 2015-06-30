using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Backbone.Logging;
using Backbone.Repository;
using Wiggle.Service.Api.Contract;
using Wiggle.Service.Models.ShoppingBasket.Request;
using Wiggle.Service.Models.ShoppingBasket.Result;

namespace Wiggle.Service.Adapter
{
    public class ShoppingBasketServiceAdapter : IShoppingBasketServiceContract
    {
        private IRepository Repository { get; set; }
        private ILogger Logger { get; set; }
     
        public ShoppingBasketServiceAdapter(ILogger logger, IRepository repository)
        {
            Repository = repository;
            Logger = logger;
        }
        
        public CalculateBasketTotalResult CalculateBasketTotal(CalculateBasketTotalRequest request)
        {
            using (var shoppingBasketService = new ShoppingBasketService(Repository,Logger))
            {
                return shoppingBasketService.CalculateBasketTotal(request);
            }
        }
    }
}
