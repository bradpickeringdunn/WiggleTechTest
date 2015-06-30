using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Services.Results;

namespace Wiggle.Service.Models.Products.Results
{
    public class GetProductsResult : GenericServiceResult
    {
        public GetProductsResult()
        {
            Product = new List<ProductDto>();
        }

        public IList<ProductDto> Product { get; set; }
    }
}
