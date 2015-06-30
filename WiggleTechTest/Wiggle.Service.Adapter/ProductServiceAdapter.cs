using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Logging;
using Backbone.Repository;
using Wiggle.Service.Api.Contract;
using Wiggle.Service.Models.Products.Results;

namespace Wiggle.Service.Adapter
{
    public class ProductServiceAdapter : IProductServiceContract
    {
        private ILogger Logger { get; set; }
        private IRepository Repository { get; set; }

        public ProductServiceAdapter(ILogger logger, IRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }

        public GetProductsResult GetProducts()
        {
            return new ProductService(Logger,Repository).GetProducts();
        }
    }
}
