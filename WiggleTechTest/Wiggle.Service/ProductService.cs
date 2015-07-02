using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Logging;
using Backbone.Repository;
using Backbone.Services.Results;
using Wiggle.Service.Api.Contract;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.Products.Results;

namespace Wiggle.Service
{
    public class ProductService : ServiceBase, IProductServiceContract
    {
        private ILogger Logger { get; set; }
        private IRepository Repository { get; set; }

        public ProductService(ILogger logger, IRepository repository)
            :base(logger)
        {
            Logger = logger;
            Repository = repository;
        }
    }
}
