using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.Products.Results;

namespace Wiggle.Service.Api.Contract
{
    [ServiceContract]
    public interface IProductServiceContract
    {
        [OperationContract]
        GetProductsResult GetProducts();
    }

}
